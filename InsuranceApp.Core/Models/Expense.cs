using InsuranceApp.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApp.Core.Models
{
    public class Expense : EntityBase
    {
        public ExpenseType Type { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        //public DateTime Date { get; set; }
    }

    public enum ExpenseType
    {
        Procedures,
        Prescriptions,
    }
}
