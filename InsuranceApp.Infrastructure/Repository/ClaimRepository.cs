using InsuranceApp.Application.Interfaces;
using InsuranceApp.Core.Models;
using InsuranceApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Infrastructure.Repository
{
    public class ClaimRepository : IClaimRepository
    {
        protected readonly InsuranceContext _dbContext;

        public ClaimRepository(InsuranceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Claim> AddClaimAsync(Claim claim)
        {
            _dbContext.Claims.Add(claim);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(claim);
            //return Task.CompletedTask;
        }

        public Task<Claim> GetClaimByIdAsync(Guid claimId)
        {
            var claim = _dbContext.Claims.SingleOrDefaultAsync(C => C.ClaimId == claimId);
            return claim;
        }

        public IEnumerable<Claim> GetClaimsAsync(string policyHolderNationalId)
        {
            var result = _dbContext.Claims.Where(O => O.PolicyHolderNationalId  == policyHolderNationalId).AsEnumerable();
            return result;
        }     

        public async Task<Claim> UpdateClaimStatusAsync(Guid claimId, ClaimStatus status)
        {
            // Additional validation or business logic can be added here
            var existingClaim = await _dbContext.Claims.FirstOrDefaultAsync(O => O.ClaimId == claimId);

            if (existingClaim != null) {
                existingClaim.Status = status;
                _dbContext.SaveChangesAsync();
                return existingClaim;
            }
            else
            {
                // TODO: Handle this
                return null;
            }

        }

       
    }
}
