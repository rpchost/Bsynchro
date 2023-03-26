using Insurance.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Insurance.Data
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options) { }

            public DbSet<Customer> Customer { get; set; }
            public DbSet<Account> Account{ get; set; }
            public DbSet<Transaction> Transaction { get; set; }

    }
}
