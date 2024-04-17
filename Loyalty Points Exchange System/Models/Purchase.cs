using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty_Points_Exchange_System.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RegisterUser")]
        public string RegisterUserId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
