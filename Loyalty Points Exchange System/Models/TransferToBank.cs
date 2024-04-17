using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty_Points_Exchange_System.Models
{
    public class TransferToBank
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RegisterUser")]
        public int RegisterUserId { get; set; }
        public int PointsTransferred { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
