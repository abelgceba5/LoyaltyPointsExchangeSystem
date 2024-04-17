using System.ComponentModel.DataAnnotations;

namespace Loyalty_Points_Exchange_System.Models
{
    public class TransferToUser
    {
        [Key]
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int PointsTransferred { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
