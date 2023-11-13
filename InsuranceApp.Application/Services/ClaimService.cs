using InsuranceApp.Application.Interfaces;
using InsuranceApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApp.Application.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimService(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        public IEnumerable<Claim> GetClaimsAsync(string policyHolderNationalId)
        {
            return _claimRepository.GetClaimsAsync(policyHolderNationalId);
        }

        public Claim AddClaimAsync(Claim claim)
        {
            claim.ClaimId = Guid.NewGuid(); // Generate a unique ID
            claim.Status = ClaimStatus.Submitted;
            //claim.DateSubmitted = DateTime.Now;

            // Additional business logic or validation can be added here
            var response = _claimRepository.AddClaimAsync(claim).Result;
            return response;
        }

        public async Task<Claim> UpdateClaimStatusAsync(Guid claimId, ClaimStatus status)
        {
            // Additional validation or business logic can be added here
            var existingClaim = await _claimRepository.UpdateClaimStatusAsync(claimId, status);
            return existingClaim;
        }

        public async Task<Claim> GetClaimByIdAsync(Guid claimId)
        {
            // Additional business logic or validation can be added here
            var existingClaim = await _claimRepository.GetClaimByIdAsync(claimId);
            return existingClaim;
        }

    }
}
