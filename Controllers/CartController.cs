
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecom.Data;
using Ecom.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Ecom.Helpers;

namespace Ecom.Controllers
{
    public class CartController : Controller
    {
        ApplicationUser ctx = new ApplicationUser();

        private readonly ApplicationDbContext _context;
        public List<CartItem> cartItem { get; set; }
        public decimal? Total { get; set; }


        public CartController(ApplicationDbContext context)

        {
            _context = context;
        }
        public ActionResult AddToCart(int productId)
        {
            var cart = new List<CartItem>();
            var product = _context.Products.FirstOrDefault(p=>p.ProductID==productId);
            if (product != null)
            {

           
            cart.Add(new CartItem()
            {
                Products = product,
                Quantity = 1
            });
                HttpContext.Session.SetObjectAsJson("cart", cart);
            }
           
                return View();
        }
        // GET: Cart
        public IActionResult Index()
        {
            cartItem = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart");
            //var result = await _context.Carts.ToListAsync();
            Total = cartItem.Sum(i => i.Products.ListPrice * i.Quantity);
            return View(cartItem
                
                );
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Carts
                .FirstOrDefaultAsync(m => m.CartID == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartID")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: Cart/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var cart = await _context.Carts.FindAsync(id);
            cartItem = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart");
            var itemToBeEdited = cartItem.Where(ci => ci.Products.ProductID == id).FirstOrDefault();
            if (!cartItem.Any())
            {
                return NotFound();
            }
            return View(itemToBeEdited);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int quantity)
        {
            cartItem = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart");
            var itemToBeEdited = cartItem.Where(ci => ci.Products.ProductID == id).FirstOrDefault();

            if (id != itemToBeEdited.Products.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    itemToBeEdited.Quantity = quantity;
                    if (quantity <= 0)
                    {
                        //redirect to delet endpoint
                    }
                    HttpContext.Session.SetObjectAsJson("cart", cartItem);

                    //_context.Update(cart);
                    //await _context.SaveChangesAsync();
                }
                //catch (DbUpdateConcurrencyException)
                //{
                //if (!CartExists(cart.CartID))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                //return RedirectToAction(nameof(Index));
            }
            return View("Edit");
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var cart = await _context.Carts
            //    .FirstOrDefaultAsync(m => m.CartID == id);
            //if (cart == null)
            //{
            //    return NotFound();
            //}

            //return View(cart);
            cartItem = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart");
            var itemToBeDeleted = cartItem.Where(ci => ci.Products.ProductID == id).FirstOrDefault();
            if (!cartItem.Any())
            {
                return NotFound();
            }
            //ViewBag.DeleteSuccess = null;

            return View(itemToBeDeleted);

        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var cart = await _context.Carts.FindAsync(id);
            //_context.Carts.Remove(cart);
            //await _context.SaveChangesAsync();
            cartItem = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart");
            var itemToBeDeleted = cartItem.Where(ci => ci.Products.ProductID == id).FirstOrDefault();
            var itemName = itemToBeDeleted.Products.ProductName;
            cartItem.Remove(itemToBeDeleted);
            HttpContext.Session.SetObjectAsJson("cart", cartItem);
            //ViewBag.DeleteSuccess = $"item {itemName} has been deleted successfully";
            // return RedirectToAction(nameof(Index));
            return View("Delete");
        }

        private bool CartExists(int id)
        {
            return _context.Carts.Any(e => e.CartID == id);
        }
    }
    //public static class SessionExtensions
    //{
    //    public static void SetObjectAsJson(this ISession session, string key, object value)
    //    {
    //        session.SetString(key, JsonConvert.SerializeObject(value));
    //    }

    //    public static T GetObjectFromJson<T>(this ISession session, string key)
    //    {
    //        var value = session.GetString(key);

    //        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    //    }
    //}
}
