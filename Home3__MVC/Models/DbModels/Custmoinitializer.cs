using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;


namespace Home3__MVC.Models
{
    internal class CustomInitializer<T> : DropCreateDatabaseAlways<ApplicationContext>
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        protected override void Seed(ApplicationContext _ctx)
        {
            _ctx.Basis.AddRange(new List<Basis>
            {
                new Basis(1.1, "Mayonnaise"),
                new Basis(1.15, "Tomatoes")
            });
            _ctx.Size.AddRange(new List<Size>
            {
                new Size(20, "Small - 25cm"),
                new Size(25, "Medium - 40cm"),
                new Size(30, "Large - 60cm")
            });
            _ctx.Sauce.AddRange(new List<Sauce>
            {
                new Sauce(8, "Barbecue"),
                new Sauce(7, "Mustard"),
                new Sauce(8, "Mayonnaise"),
                new Sauce(7, "Acute"),
                new Sauce(8, "Cheesy"),
                new Sauce(7, "Garlic")
            });
            _ctx.Ingredient.AddRange(new List<Ingredient>
            {
                new Ingredient(6.0, 50, "Pineapple"),
                new Ingredient(6.0, 50, "Bolognese"),
                new Ingredient(6.5, 50, "Bacon"),
                new Ingredient(6.0, 80, "Brynza"),
                new Ingredient(2.5, 15, "Olive"),
                new Ingredient(2.5, 30, "Corn"),
                new Ingredient(4.0, 50, "Tomato"),
                new Ingredient(7.5, 60, "Ham"),
                new Ingredient(4.5, 40, "Champignons"),
                new Ingredient(6.0, 50, "Salami"),
                new Ingredient(5.0, 40, "Chicken")
            });
            _ctx.SaveChanges();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_ctx));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_ctx));
                       
            var adminRole = new IdentityRole { Name = "admin" };
            var userRole = new IdentityRole { Name = "user" };

            roleManager.Create(adminRole);
            roleManager.Create(userRole);

            var password = "Qwerty_123";

            ApplicationUser user = new ApplicationUser { Name = "Vasya", UserName = "vasya@gmail.com", Email = "vasya@gmail.com", PhoneNumber = "+380980630555", Address = "Rivne, Soborna, 1" };
            var result = userManager.Create(user, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, userRole.Name);
            }

            ApplicationUser admin = new ApplicationUser { Name = "Admin", UserName = "admin@gmail.com", Email = "admin@gmail.com", PhoneNumber = "+380980630999", Address = "Rivne, Soborna, 2" };
            result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
            }
            base.Seed(_ctx);
        }
    }
}