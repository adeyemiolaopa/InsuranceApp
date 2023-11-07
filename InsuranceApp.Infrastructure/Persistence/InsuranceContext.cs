using InsuranceApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Infrastructure.Persistence
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options) : base(options)
        {
        }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<PolicyHolder> PolicyHolders { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}
