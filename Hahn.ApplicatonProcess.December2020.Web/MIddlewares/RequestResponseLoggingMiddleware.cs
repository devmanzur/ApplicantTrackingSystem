﻿using System;
using System.IO;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.IO;

namespace Hahn.ApplicatonProcess.December2020.Web.MIddlewares
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggingBroker _loggingBroker;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;


        public RequestResponseLoggingMiddleware(RequestDelegate next, ILoggingBroker loggingBroker)
        {
            _next = next;
            _loggingBroker = loggingBroker;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task Invoke(HttpContext context)
        {
            await LogRequest(context);
            await LogResponse(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            context.Request.EnableBuffering();
            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await context.Request.Body.CopyToAsync(requestStream);
            _loggingBroker.LogInformation(message:
                "Http Request Information: {Environment} Schema:{Schema} Host: {Host} Path: {Path} QueryString: {QueryString} Response Body: {RequestBody}",
                Environment.NewLine, context.Request.Scheme, context.Request.Host, context.Request.Path,
                context.Request.QueryString, ReadStreamInChunks(requestStream));
            context.Request.Body.Position = 0;
        }

        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;
            stream.Seek(0, SeekOrigin.Begin);
            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);
            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;
            do
            {
                readChunkLength = reader.ReadBlock(readChunk,
                    0,
                    readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);

            return textWriter.ToString();
        }

        private async Task LogResponse(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;
            await _next(context);
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            _loggingBroker.LogInformation(
                "Http Request Information: {Environment} Schema:{Schema} Host: {Host} Path: {Path} QueryString: {QueryString} Response Body: {ResponseBody}",
                Environment.NewLine, context.Request.Scheme, context.Request.Host, context.Request.Path, text);
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}