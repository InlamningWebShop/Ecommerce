using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public CartItem CartItems { get; set;}
    }
}
