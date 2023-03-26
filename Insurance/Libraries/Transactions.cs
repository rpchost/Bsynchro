using Insurance.Data;
using Insurance.Models;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Libraries
{
    public class Transactions
    {
        public static (bool, string) CreateTransaction(int AccountId, double InitialCredit, InsuranceDbContext _context)
        {
            try
            {
                var Account = _context.Account.FirstOrDefault(a => a.Id == AccountId);
                if (Account == null)
                    return (false, $"AccountId {AccountId} does not exist");

                Transaction transaction = new Transaction
                {
                    AccountId = AccountId,
                    TransactionDate = DateTime.UtcNow
                };

                //Update Account balance
                double newAccountBalance = InitialCredit + Account.Balance;
                Account.Balance = newAccountBalance;
                _context.Account.Update(Account);

                //Add new Transaction
                transaction.setAmount(InitialCredit);
                _context.Transaction.Add(transaction);

                _context.SaveChanges();

                return (true, "");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
