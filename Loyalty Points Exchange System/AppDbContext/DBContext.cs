
using Loyalty_Points_Exchange_System.Models;
using LoyaltyPointsExchangeSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyPointsExchangeSystem.AppDbContext
{
    public class DBContext: DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {


        }

        public DbSet<Login> logins { get; set; }
        public DbSet<RegisterUser> registerUsers { get; set; }
        public DbSet<EarnPoints> earnPoints { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<LoyaltyPoint> loyaltyPoints { get; set; }
        public DbSet<Purchase> purchases { get; set; }

        public DbSet<RedeemPoints> redeemPoints { get; set; }

        public DbSet<TransactionHistory> transactionHistories { get; set; }
        public DbSet<TransferToBank> transferToBanks { get; set; }

        public  DbSet<TransferToUser> TransferToUsers { get; set; }
       
        public DbSet<BankAccount> BankAccounts { get; set; }





    }
}
