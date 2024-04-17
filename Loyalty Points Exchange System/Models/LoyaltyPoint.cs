using System.ComponentModel.DataAnnotations;

namespace Loyalty_Points_Exchange_System.Models
{
    public class LoyaltyPoint
    {
        [Key]
        public int Id { get; set; }
        public string RegisterUserId { get; set; }
        public int TotalPoints { get; set; }
    }
}
