using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoyaltyPointsExchangeSystem.Models
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RegisterUser")]
        public int RegisterUserId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
