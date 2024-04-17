using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty_Points_Exchange_System.Models
{


    public enum TransactionType
    {
        EarnPoints,
        RedeemPoints,
        TransferToBank,
        TransferToUser
    }
    public class TransactionHistory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RegisterUser")]
        public int RegisterUserId { get; set; }
        public TransactionType Type { get; set; }
        public int PointsChanged { get; set; }
        public decimal AmountChanged { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
