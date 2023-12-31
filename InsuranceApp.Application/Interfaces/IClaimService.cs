﻿using InsuranceApp.Core.Models;

namespace InsuranceApp.Application.Interfaces
{
    public interface IClaimService
    {
        Claim AddClaimAsync(Claim claim);
        IEnumerable<Claim> GetClaimsAsync(string policyHolderNationalId);
        Task<Claim> UpdateClaimStatusAsync(Guid claimId, ClaimStatus status);
        Task<Claim> GetClaimByIdAsync(Guid claimId);
    }
}
