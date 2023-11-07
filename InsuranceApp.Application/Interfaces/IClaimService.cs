using InsuranceApp.Core.Models;

namespace InsuranceApp.Application.Interfaces
{
    public interface IClaimService
    {
        Task<Claim> AddClaimAsync(Claim claim);
        IAsyncEnumerable<Claim> GetClaimsAsync(string policyHolderNationalId);
        Task<Claim> UpdateClaimStatusAsync(Guid claimId, ClaimStatus status);
        Task<Claim> GetClaimByIdAsync(Guid claimId);
    }
}
