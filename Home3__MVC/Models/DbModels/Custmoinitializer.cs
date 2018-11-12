using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Home3__MVC.Models.DbModels;
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

            ApplicationUser user = new ApplicationUser { Name="test", UserName = "test@test.test", Email = "test@test.test", PhoneNumber = "+380988545888", Address = "testAddr"};
            UserManager.CreateAsync(user, "Qwerty_123");
        }
    }
}