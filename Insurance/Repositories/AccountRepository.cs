using Insurance.Data;
using Insurance.Interfaces;
using Insurance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Insurance.Libraries.ActionResults;
using static Insurance.Libraries.Transactions;

namespace Insurance.Repositories
{
    public class AccountRepository : IAccount
    {
        private InsuranceDbContext _context;
        private readonly ILogger<AccountRepository> _log;
        public AccountRepository(ILogger<AccountRepository> log, InsuranceDbContext context)
        {
            _context = context;
            _log = log;
        }

        public async Task<IActionResult> CreateAccount(int CustomerId, double InitialCredit)
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    var CustomerExists = await _context.Customer.Include(a => a.account)
                                                     .FirstOrDefaultAsync(c => c.Id == CustomerId);

                    if (CustomerExists != null)
                    {
                        _log.LogError($"Customer {CustomerId} already exists");
                        return AlreadyExists();
                    }

                    //If new Customer => Create a new account
                    Account account = new Account
                    {
                        Balance = InitialCredit,
                        CustomerId = CustomerId,
                        DateCreation = DateTime.UtcNow,
                        Status = 'A'
                    };

                    _context.Account.Add(account);
                    await _context.SaveChangesAsync();

                    if (account.Id > 0) //If account created
                    {
                        if (CreateTransaction(account.Id, InitialCredit, _context).Item1 == true) //Create a new transaction
                        {
                            await transaction.CommitAsync();
                            return Ok();
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                        }
                    }
                    return InternalServerError();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _log.LogError($"Concurrency Exception {ex.Message}");
                return InternalServerError();
            }
            catch (Exception ex)
            {
                _log.LogError($"Error exception {ex.Message}");
                return InternalServerError();
            }
        }
    }
}
