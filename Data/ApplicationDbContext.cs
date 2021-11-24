using Ecom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Data
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser()
        {
            Carts = new List<Cart>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Cart> Carts { get; set; }

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

    }
}
