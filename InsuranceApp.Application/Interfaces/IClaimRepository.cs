using InsuranceApp.Core.Models;

namespace InsuranceApp.Application.Interfaces
{
    public interface IClaimRepository
    {
        Task<Claim> AddClaimAsync(Claim claim);
        Task<Claim> GetClaimByIdAsync(Guid claimId);
        IAsyncEnumerable<Claim> GetClaimsAsync(string policyHolderNationalId);
        Task<Claim> UpdateClaimStatusAsync(Guid claimId, ClaimStatus status);
    }
}
