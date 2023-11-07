using InsuranceApp.Application.Interfaces;
using InsuranceApp.Core.Models;

namespace InsuranceApp.Application.Services
{
    public class PolicyHolderService : IPolicyHolderService
    {
        private readonly IPolicyHolderRepository _policyHolderRepository;

        public PolicyHolderService(IPolicyHolderRepository policyHolderRepository)
        {
            _policyHolderRepository = policyHolderRepository;
        }

        public Task<PolicyHolder> AddPolicyHolder(PolicyHolder policyHolder)
        {
            policyHolder.NationalId = Guid.NewGuid().ToString(); // Generate a unique ID
            //policyHolder.DateSubmitted = DateTime.Now;

            // Additional business logic or validation can be added here
            var response = _policyHolderRepository.AddPolicyHolder(policyHolder).Result;
            return Task.FromResult(response);
        }
    }
}
