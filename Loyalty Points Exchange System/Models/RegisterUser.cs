using Loyalty_Points_Exchange_System.Models;
using System.ComponentModel.DataAnnotations;

namespace LoyaltyPointsExchangeSystem.Models
{
    public class RegisterUser
    {

        [Key]

        public int RegisterUserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual ICollection<EarnPoints> EarnedPoints { get; set; }
    }
}
