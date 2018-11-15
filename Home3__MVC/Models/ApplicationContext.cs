using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Home3__MVC.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        private static ApplicationContext instance;

        public ApplicationContext() : base("IdentityDb")
        {
            
        }

        public static ApplicationContext getInstance()
        {
            if (instance == null)
                instance = new ApplicationContext();
            return instance;
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> ItemOrder { get; set; }
        public virtual DbSet<Basis> Basis { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Sauce> Sauce { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
    }
}