using InsuranceApp.Application.Interfaces;
using InsuranceApp.Core.Models;
using InsuranceApp.Infrastructure.Persistence;

namespace InsuranceApp.Infrastructure.Repository
{
    public class PolicyHolderRepository : IPolicyHolderRepository
    {
        protected readonly InsuranceContext _dbContext;

        public PolicyHolderRepository(InsuranceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<PolicyHolder> AddPolicyHolder(PolicyHolder policyHolder)
        {
            _dbContext.PolicyHolders.Add(policyHolder);
            _dbContext.SaveChangesAsync();
            return Task.FromResult(policyHolder);
        }
    }
}
