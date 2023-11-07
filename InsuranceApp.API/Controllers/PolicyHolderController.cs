using InsuranceApp.Application.Interfaces;
using InsuranceApp.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InsuranceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyHolderController : ControllerBase
    {
        private readonly ILogger<ClaimController> _logger;
        private readonly IPolicyHolderService _policyHolderService;

        public PolicyHolderController(ILogger<ClaimController> logger, IPolicyHolderService policyHolderService)
        {
            _logger = logger;
            _policyHolderService = policyHolderService;
        }

        [HttpPost("AddPolicyHolder")]
        [ProducesResponseType(typeof(PolicyHolder), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PolicyHolder>> AddPolicyHolder([FromBody] PolicyHolder request)
        {
            // I would have used a DTO object here and mapper if not for the time constraint
            var result = await _policyHolderService.AddPolicyHolder(request);
            return Ok(result);
        }


    }
}
