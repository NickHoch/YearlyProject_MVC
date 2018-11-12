using Home3__MVC.Models;
using Home3__MVC.Models.DbModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Home3__MVC.Controllers
{
    public class HomeController : Controller
    {
        private static ApplicationContext _ctx = new ApplicationContext();
        private static int Counter = 1;

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        public async Task<ActionResult> Index()
        {
            HomeViewModel model = new HomeViewModel(_ctx.Basis.ToList(), _ctx.Size.ToList(), _ctx.Sauce.ToList(), _ctx.Ingredient.ToList());
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                model.Order.Name = user.Name;
                model.Order.Address = user.Address;
                model.Order.PhoneNumber = user.PhoneNumber;
            }
            return View(model);
        }

        public ActionResult Bucket()
        {
            Order model = new Order();
            if (Session["Bucket"] != null)
            {
                model = Session["Bucket"] as Order;
            }
            return View(model);
        }

        public void DeleteOrderItem(int id)
        {
            Order order = Session["Bucket"] as Order;
            order.Items.Remove(order.Items.SingleOrDefault(x => x.Id == id));
            Session["Bucket"] = order;
        }
        public void MakeOrder(string clientName, string clientNumber, string clientAddress)
        {
            //Order order = new Order
            //{
            //    Info = new ContactInfo
            //    {
            //        Name = clientName,
            //        PhoneNumber = clientNumber,
            //        Address = clientAddress
            //    },
            //    Items = Session["Bucket"] as List<ItemOrder>
            //};
            //_ctx.Orders.Add(order);
            //_ctx.SaveChanges();
            //Session["OrderList"] = null;
            //Session["TotalSum"] = null;
        }
        public async Task AddToBucket(BucketItem bucketItem)
        {
            Order order = null;
            if (Session["Bucket"] == null)
            {
                order = new Order();
                ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
                if (user != null)
                {
                    order.User = user;
                    order.Name = user.Name;
                    order.PhoneNumber = user.PhoneNumber;
                    order.Address = user.Address;
                }
            }
            else
            {
                order = Session["Bucket"] as Order;
            }

            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var item in bucketItem.ingridIds)
            {
                ingredients.Add(_ctx.Ingredient.SingleOrDefault(x => x.Id == item));
            }
            Pizza pizza = new Pizza(
                _ctx.Basis.SingleOrDefault(x => x.Id == bucketItem.basisId),
                _ctx.Size.SingleOrDefault(x => x.Id == bucketItem.sizeId),
                _ctx.Sauce.SingleOrDefault(x => x.Id == bucketItem.sauceId),
                ingredients,
                bucketItem.weight,
                bucketItem.price
            );
            order.Items.Add(new OrderItem(Counter++, bucketItem.quantity, pizza));
            Session["Bucket"] = null;
            Session["Bucket"] = order;
        }
    }
}