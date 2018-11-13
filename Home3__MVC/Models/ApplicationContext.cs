using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Home3__MVC.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("IdentityDb")
        {
            Database.SetInitializer<ApplicationContext>(new CustomInitializer<ApplicationContext>());
        }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>()
        //        .HasOptional(o => o.User)
        //        .WithMany(u => u.Orders);
        //    base.OnModelCreating(modelBuilder);
        //}
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> ItemOrder { get; set; }
        public virtual DbSet<Basis> Basis { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Sauce> Sauce { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
    }
}