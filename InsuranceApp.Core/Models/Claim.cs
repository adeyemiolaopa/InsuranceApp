using InsuranceApp.Core.Common;

namespace InsuranceApp.Core.Models
{
    public class Claim : EntityBase
    {
        public Guid ClaimId { get; set; }
        public string PolicyHolderNationalId { get; set; }
        public List<Expense> Expenses { get; set; }
        public ClaimStatus Status { get; set; }
    }

    public enum ClaimStatus
    {
        Submitted,
        Approved,
        Declined,
        InReview
    }
}
