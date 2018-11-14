using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Home3__MVC.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        private static ApplicationContext instance;

        private ApplicationContext() : base("IdentityDb")
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
        //private ApplicationContext(string cs) : base(cs)
        //{
        //    Database.SetInitializer<ApplicationContext>(new CustomInitializer<ApplicationContext>());
        //}
        //public static ApplicationContext Create(string cs)
        //{
        //    return new ApplicationContext(cs);
        //}

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