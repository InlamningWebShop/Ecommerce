using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ListPrice { get; set; }
        //[ForeignKey("Category")]
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        //public Stock Stocks { get; set; }
        //public ICollection<CartItem> CartItems { get; set; }

    }
}
