using Ecom.Data;
using Ecom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Ecom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public const string SessionKeyName = "_TestName";
        public const string SessionKeyAge = "_Age";
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context
            )
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShoppingCart()
        {
            return View();
        }
        public IActionResult CheckoutDetails()
        {
            return View();
        }
        ////GET
        //public IActionResult ShowProductsPage()
        //{
        //    var productList = _context.Products.Select(p => p).ToList();
        //    // ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
        //    HttpContext.Session.SetString(SessionKeyName, "The Doctor test");
        //    return PartialView("ProductCards", productList);
        //}
        //POST
        //public IActionResult AddProductToCard(int id)
        //{
        //    var productToBeAdded = _context.Products.Where(p => p.ProductID == id).FirstOrDefault();
        //    //Session update
        //    // ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
        //    //return PartialView("ProductCards", productList);
        //    return Ok();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}