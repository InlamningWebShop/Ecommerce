using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class produktCategoriModel
    {
        [Key]
        public int ID { get; set; }
        public string ProduktCategori { get; set; } 
    }
}
