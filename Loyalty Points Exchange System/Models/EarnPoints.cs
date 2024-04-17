using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty_Points_Exchange_System.Models
{
    public class EarnPoints
    {
        [Key]

        public int Id { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        [ForeignKey("RegisterUser")]
        public int RegisterUserId { get; set; }
        public int PointsEarned { get; set; }
        public DateTime EarnedDate { get; set; }
        public int TotalPointsEarned { get; set; }
    }
}
