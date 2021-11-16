using Ecom.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ecom.Controllers
{
    public class ProduktCategori : ControllerBase
    {


      
        private readonly ApplicationDbContext _context;
        public ProduktCategori(ApplicationDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public List<ActionResult > GetProducts ()
        //{

        //  return  _context.Products.AllAsync();
        //}
    }
}
