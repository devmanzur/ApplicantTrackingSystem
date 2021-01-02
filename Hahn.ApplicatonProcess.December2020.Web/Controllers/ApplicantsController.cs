using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Dto;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Web.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet]
        public async Task<ActionResult<Envelope<List<ApplicantResponse>>>> GetApplicants()
        {
            var applicants = await _applicantService.RetrieveAllApplicants();
            return Ok(Envelope.Ok(applicants.Select(ApplicantResponse.Map).ToList()));
        }

        [HttpGet("{applicantId}")]
        public async Task<ActionResult<Envelope<ApplicantResponse>>> GetApplicant(int applicantId)
        {
            var retrieveApplicant = await _applicantService.RetrieveApplicantById(applicantId);
            if (retrieveApplicant.IsSuccess)
            {
                return Ok(Envelope.Ok(ApplicantResponse.Map(retrieveApplicant.Value)));
            }

            return UnprocessableEntity(Envelope.Error(retrieveApplicant.Error));
        }

        [HttpDelete("{applicantId}")]
        public async Task<ActionResult<Envelope<ApplicantResponse>>> RemoveApplicant(int applicantId)
        {
            var removeApplicant = await _applicantService.RemoveApplicant(applicantId);
            if (removeApplicant.IsSuccess)
            {
                return Ok(Envelope.Ok(ApplicantResponse.Map(removeApplicant.Value)));
            }

            return UnprocessableEntity(Envelope.Error(removeApplicant.Error));
        }

        [HttpPut("{applicantId}")]
        public async Task<ActionResult<Envelope<ApplicantResponse>>> ModifyApplicant(int applicantId,
            [FromBody] ApplicantDto dto)
        {
            var modifyApplicant = await _applicantService.ModifyApplicant(applicantId, dto);
            if (modifyApplicant.IsSuccess)
            {
                return Ok(Envelope.Ok(ApplicantResponse.Map(modifyApplicant.Value)));
            }

            return UnprocessableEntity(Envelope.Error(modifyApplicant.Error));
        }

        [HttpPost]
        public async Task<ActionResult<Envelope<ApplicantResponse>>> RegisterApplicant([FromBody] ApplicantDto dto)
        {
            var registerApplicant = await _applicantService.RegisterApplicant(dto);
            if (registerApplicant.IsSuccess)
            {
                return CreatedAtAction(nameof(GetApplicant),
                    new {applicantId = registerApplicant.Value.Id},
                    Envelope.Ok(ApplicantResponse.Map(registerApplicant.Value)));
            }

            return BadRequest(Envelope.Error(registerApplicant.Error));
        }
    }
}