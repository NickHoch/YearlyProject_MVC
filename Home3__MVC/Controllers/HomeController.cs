using Home3__MVC.Models;
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
        private ApplicationContext _ctx = ApplicationContext.getInstance();
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
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                if(User.IsInRole("admin"))
                {
                    return RedirectToAction("Index", new { area = "Admin", controller = "Home" });
                }
                model.Order.ContactInfo.Name = user.Name;
                model.Order.ContactInfo.Address = user.Address;
                model.Order.ContactInfo.PhoneNumber = user.PhoneNumber;
            }
            return View(model);
        }
        [ChildActionOnly]
        public async Task<Order> SetUserInfo(Order model)
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                model.UserId = user.Id;
                model.ContactInfo.Name = user.Name;
                model.ContactInfo.PhoneNumber = user.PhoneNumber;
                model.ContactInfo.Address = user.Address;
            }
            return model;
        }
        [HttpGet]
        public async Task<ActionResult> Bucket()
        {
            Order model = null;
            if (Session["Bucket"] != null)
            {
                model = Session["Bucket"] as Order;
                if (model.UserId == null)
                {
                    model = await SetUserInfo(model);
                }
            }
            else
            {
                model = new Order();
                model = await SetUserInfo(model);
            }
            return View(model);
        }
        public void DeleteOrderItem(int id)
        {
            Order order = Session["Bucket"] as Order;
            order.Items.Remove(order.Items.SingleOrDefault(x => x.Id == id));
            Session["Bucket"] = order;
        }
        [HttpPost]
        public ActionResult MakeOrder(ContactInfo contactInfo)
        {
            Order order = Session["Bucket"] as Order;
            if(order == null)
            {
                return RedirectToAction("Bucket");
            }
            order.ContactInfo.Name = contactInfo.Name;
            order.ContactInfo.PhoneNumber = contactInfo.PhoneNumber;
            order.ContactInfo.Address = contactInfo.Address;
            order.OrderTime = DateTime.Now;
            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
            Session["Bucket"] = null;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task AddToBucket(BucketItemModel bucketItem)
        {
            Order order = null;
            if (Session["Bucket"] == null)
            {
                order = new Order();
                ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    order.UserId = user.Id;
                    order.ContactInfo.Name = user.Name;
                    order.ContactInfo.PhoneNumber = user.PhoneNumber;
                    order.ContactInfo.Address = user.Address;
                }
            }
            else
            {
                order = Session["Bucket"] as Order;
            }

            List<Ingredient> ingredients = new List<Ingredient>();
            if(bucketItem.ingridIds != null)
            {
                foreach (var item in bucketItem.ingridIds)
                {
                    ingredients.Add(_ctx.Ingredient.SingleOrDefault(x => x.Id == item));
                }
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
        public bool CheckEmail(string email)
        {
            return _ctx.Users.Any(x => x.Email == email);
        }
    }
}