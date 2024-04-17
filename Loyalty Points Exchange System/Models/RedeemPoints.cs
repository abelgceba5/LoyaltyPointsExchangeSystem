using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty_Points_Exchange_System.Models
{
    public class RedeemPoints
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RegisterUser")]
        public int RegisterUserId { get; set; }
        public int PointsRedeemed { get; set; }
        public decimal AmountRedeemed { get; set; }
        public DateTime RedeemedDate { get; set; }
    }
}
