using InsuranceApp.Core.Models;

namespace InsuranceApp.Application.Interfaces
{
    public interface IPolicyHolderRepository
    {
        Task<PolicyHolder> AddPolicyHolder(PolicyHolder policyHolder);
    }
}
