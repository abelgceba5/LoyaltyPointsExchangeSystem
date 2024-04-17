using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty_Points_Exchange_System.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("RegisterUser")]
        public int? RegisteredUserId { get; set; }
    }
}
