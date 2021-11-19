using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        //[Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
