using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Dto;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Web.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet]
        public async Task<ActionResult<Envelope<List<Applicant>>>> GetApplicants()
        {
            var applicants = await _applicantService.RetrieveAllApplicants();
            return Ok(Envelope.Ok(applicants));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Envelope<Applicant>>> GetApplicant(int id)
        {
            var retrieveApplicant = await _applicantService.RetrieveApplicantById(id);
            if (retrieveApplicant.IsSuccess)
            {
                return Ok(Envelope.Ok(retrieveApplicant.Value));
            }

            return UnprocessableEntity(Envelope.Error(retrieveApplicant.Error));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Envelope<Applicant>>> RemoveApplicant(int id)
        {
            var removeApplicant = await _applicantService.RemoveApplicant(id);
            if (removeApplicant.IsSuccess)
            {
                return Ok(Envelope.Ok(removeApplicant.Value));
            }

            return UnprocessableEntity(Envelope.Error(removeApplicant.Error));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Envelope<Applicant>>> ModifyApplicant(int id, [FromBody] ApplicantDto dto)
        {
            var modifyApplicant = await _applicantService.ModifyApplicant(id, dto);
            if (modifyApplicant.IsSuccess)
            {
                return Ok(Envelope.Ok(modifyApplicant.Value));
            }

            return UnprocessableEntity(Envelope.Error(modifyApplicant.Error));
        }

        [HttpPost]
        public async Task<ActionResult<Envelope<Applicant>>> RegisterApplicant([FromBody] ApplicantDto dto)
        {
            var registerApplicant = await _applicantService.RegisterApplicant(dto);
            if (registerApplicant.IsSuccess)
            {
                return CreatedAtAction(nameof(GetApplicant),
                    new {id = registerApplicant.Value.Id}, registerApplicant);
            }

            return BadRequest(Envelope.Error(registerApplicant.Error));
        }
    }
}