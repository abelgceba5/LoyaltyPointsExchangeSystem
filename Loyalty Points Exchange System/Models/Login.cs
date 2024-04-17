using System.ComponentModel.DataAnnotations;

namespace LoyaltyPointsExchangeSystem.Models
{
    public class Login
    {

        [Key]

        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
