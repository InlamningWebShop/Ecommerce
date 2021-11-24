using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Cart
    {
        public Cart()
        {

        }
        [Key]
        public int CartID { get; set; }
        public string UserId { get; set; }

        public CartItem CartItems { get; set;}
    }
}
