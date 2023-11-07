using InsuranceApp.Core.Common;
using InsuranceApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApp.Application.DTOs
{
    public class ClaimRequest : EntityBase
    {
        //public Guid ClaimId { get; set; }
        public string PolicyHolderNationalId { get; set; }
        public List<Expense> Expenses { get; set; }
        public ClaimStatus Status { get; set; }
    }
}
