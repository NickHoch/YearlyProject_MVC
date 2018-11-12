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
        public static ApplicationContext _ctx = new ApplicationContext();

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
            if(Session["Bucket"] != null)
            {
                model = Session["Bucket"] as Order;
            }
            return View(model);
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

    
        public async Task AddToBucket(string basisId, string sizeId, string sauceId, string ingridId, string quantity, string weight, string price)
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

            bool flag = true;
            int basisIdInt;
            if (!Int32.TryParse(basisId, out basisIdInt))
            {
                flag = false;
            }
            int sizeIdInt;
            if (!Int32.TryParse(sizeId, out sizeIdInt))
            {
                flag = false;
            }
            int sauceIdInt;
            if (!Int32.TryParse(sauceId, out sauceIdInt))
            {
                flag = false;
            }
            int quantityInt;
            if (!Int32.TryParse(quantity, out quantityInt))
            {
                flag = false;
            }
            double weightDouble;
            if (!Double.TryParse(weight, out weightDouble))
            {
                flag = false;
            }
            double priceDouble;
            if (!Double.TryParse(price, out priceDouble))
            {
                flag = false;
            }
            List<int> ingridIdInt = new List<int>();
            if (ingridId != null)
            {
                List<string> ingridIdList = ingridId.Split(',').ToList<string>();
                foreach (var item in ingridIdList)
                {
                    int id;
                    if (Int32.TryParse(item, out id))
                    {
                        ingridIdInt.Add(id);
                    }
                }
            }          

            if (flag)
            {
                List<Ingredient> ingredients = new List<Ingredient>();
                foreach (var item in ingridIdInt)
                {
                    ingredients.Add(_ctx.Ingredient.SingleOrDefault(x => x.Id == item));
                }
                Pizza pizza = new Pizza(
                    _ctx.Basis.SingleOrDefault(x => x.Id == basisIdInt),
                    _ctx.Size.SingleOrDefault(x => x.Id == sizeIdInt),
                    _ctx.Sauce.SingleOrDefault(x => x.Id == sauceIdInt),
                    ingredients,
                    weightDouble,
                    priceDouble
                );
                order.Items.Add(new ItemOrder(quantityInt, pizza));
                Session["Bucket"] = null;
                Session["Bucket"] = order;
            };
        }
    }
}