using Loyalty_Points_Exchange_System.Interface;
using Loyalty_Points_Exchange_System.Models;
using LoyaltyPointsExchangeSystem.AppDbContext;
using LoyaltyPointsExchangeSystem.Interface;
using LoyaltyPointsExchangeSystem.Models;
using Microsoft.EntityFrameworkCore;
//using static LoyaltyPointsExchangeSystem.Interface.ITransactionHistory;

namespace LoyaltyPointsExchangeSystem.Provider
{
    public class BankAccountProvider:IBankAccount
    {

        private readonly DBContext _dBContext;
        private readonly ITransactionHistory _transactionHistory;

        public BankAccountProvider(DBContext dbContext, ITransactionHistory transactionHistory)
        {

            _dBContext = dbContext;
            _transactionHistory = transactionHistory;
        }


        public async Task<BankAccount> CreateBankAccountAsync(int userId, decimal initialBalance)
        {
            // Generate a 10-digit random account number
            string accountNumber = GenerateAccountNumber();

            // Create the BankAccount object
            var bankAccount = new BankAccount
            {
                RegisterUserId = userId,
                AccountNumber = accountNumber,
                Balance = initialBalance
            };

            // Add BankAccount to the database
            _dBContext.BankAccounts.Add(bankAccount);
            await _dBContext.SaveChangesAsync();

            await _transactionHistory.RecordTransactionAsync(userId, TransactionType.TransferToBank, 0, initialBalance, DateTime.Now);

            return bankAccount;
        }

            private string GenerateAccountNumber()
        {
            // Generate a 10-digit random account number
            var random = new Random();
            string accountNumber = new string(Enumerable.Range(0, 10).Select(_ => (char)('0' + random.Next(10))).ToArray());
            return accountNumber;
        }
    }
}
