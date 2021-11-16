using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Stock
    {
        public Product Product { get; set; }
        [Key]
        public int ProductID { get; set; }
        public int? Quantity { get; set; }


    }
}
