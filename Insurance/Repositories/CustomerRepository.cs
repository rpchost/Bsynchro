using Insurance.Data;
using Insurance.Interfaces;
using Insurance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Insurance.Libraries.ActionResults;

namespace Insurance.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private InsuranceDbContext _context;
        private readonly ILogger<CustomerRepository> _log;
        public CustomerRepository(ILogger<CustomerRepository> log, InsuranceDbContext context)
        {
            _context = context;
            _log = log;
        }

        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            var Exist = await _context.Customer.AsNoTracking()
                                               .FirstOrDefaultAsync(c => c.FName == customer.FName && c.LName == customer.LName);

            if (Exist != null)
            {
                _log.LogError($"Customer {customer.FName} {customer.LName} already exists");
                throw new ArgumentException($"Customer {customer.FName} {customer.LName} already exists");
            }

            customer.setGuid(Guid.NewGuid());
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return Ok();
        }

        public async Task<Customer?> GetCustomer(Guid? guid, int? Id)
        {
            return await _context.Customer.AsNoTracking()
                                          .FirstOrDefaultAsync(c => c.getGuid() == guid || c.Id == Id);
        }
    }
}
