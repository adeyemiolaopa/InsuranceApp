using InsuranceApp.Core.Models;

namespace InsuranceApp.Application.Interfaces
{
    public interface IPolicyHolderService
    {
        Task<PolicyHolder> AddPolicyHolder(PolicyHolder policyHolder);
    }
}
