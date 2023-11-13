using InsuranceApp.Application.DTOs;
using InsuranceApp.Application.Interfaces;
using InsuranceApp.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InsuranceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly ILogger<ClaimController> _logger;
        private readonly IClaimService _claimService;

        public ClaimController(IClaimService claimService)
        {
            //_logger = logger;
            _claimService = claimService;
        }

        [HttpPost("AddClaim")]
        //[ProducesResponseType(typeof(Claim), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddClaim([FromBody] Claim request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // I would have used a DTO object here and mapper if not for the time constraint
                    var result = _claimService.AddClaimAsync(request);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetClaimById")]
        [ProducesResponseType(typeof(Claim), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Claim>> GetClaimById(Guid claimId)
        {
            try
            {
                var result = await _claimService.GetClaimByIdAsync(claimId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetClaims")]
        //[ProducesResponseType(typeof(List<Claim>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetClaims(string placeHolderId)
        {
            try
            {
                var result = _claimService.GetClaimsAsync(placeHolderId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
