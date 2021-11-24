using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class CartItem
    {
        [Key]
        public int ItemID { get; set; }
        public Product Products { get; set;}
        public int ProductID { get; set; }
        public int? Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public Cart Carts { get; set; }
        public int CartID { get; set; }
    }
}
