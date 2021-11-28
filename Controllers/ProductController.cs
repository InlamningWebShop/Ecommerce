using Ecom.Data;
using Ecom.Models;
using Ecom.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public List<CartItem> cartItem { get; set; }
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

                var productList = _context.Products.Select(p => p).ToList();
                // ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryName");
                //HttpContext.Session.SetString(SessionKeyName, "The Doctor test");
            return View(productList);
        }
        //POST
        public IActionResult AddProductToCard(int id)
        {
            var productToBeAdded = _context.Products.Where(p => p.ProductID == id).FirstOrDefault();
           // var productModel = new Product();
            //cartItem = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            cartItem = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart");
            if (cartItem == null)
            {
                cartItem = new List<CartItem>();
                cartItem.Add(new CartItem
                {
                    Products = productToBeAdded,
                    Quantity = 1
                });
                //SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartItem);
                HttpContext.Session.SetObjectAsJson("cart", cartItem);
            }
            else
            {
                var itemAlreadyInCart = ItemExists(cartItem, id);
                if (itemAlreadyInCart != true)
                {
                    cartItem.Add(new CartItem
                    {
                        Products = productToBeAdded,
                        Quantity = 1
                    });
                }
                else
                {
                    foreach (var item in cartItem)
                    {
                        item.Quantity++;
                    }
                }
                HttpContext.Session.SetObjectAsJson("cart", cartItem);
            }
            return RedirectToAction("Index", "Cart");
        }
        public bool ItemExists(List<CartItem> cartItem, int id)
        {
            //for (var i = 0; i < cartItem.Count; i++)
            //{
            //    if (cart[i].Product.Id == id)
            //    {
            //        return i;
            //    }
            //}
            //return -1;
            var itemExists = false;
            foreach (var item in cartItem)
            {
                if (item.Products.ProductID == id)
                {
                    itemExists = true;
                    continue;
                }
                
            }
                return itemExists;
        }
    }
}
