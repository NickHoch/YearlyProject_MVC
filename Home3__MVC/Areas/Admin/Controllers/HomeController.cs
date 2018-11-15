using Home3__MVC.Areas.Admin.Models;
using Home3__MVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Home3__MVC.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _ctx = ApplicationContext.getInstance();
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult DisplayUsers()
        {
            var users = _ctx.Users.Where(x => x.UserName != User.Identity.Name).ToList();
            var displayUsers = users.Select(x => new DisplayUserModel(x.Id, x.Email, x.PhoneNumber, x.Name, x.Address));
            return View(displayUsers);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> CreateUser(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if(model.IsAdmin)
                    {
                        await UserManager.AddToRoleAsync(user.Id, "admin");
                    }
                    else
                    {
                        await UserManager.AddToRoleAsync(user.Id, "user");
                    }
                    return RedirectToAction("DisplayUsers");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return RedirectToAction("DisplayUsers");
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteUser(string id)
        {
            var user = _ctx.Users.SingleOrDefault(x => x.Id == id);
            _ctx.Users.Remove(user);
            _ctx.SaveChanges();
            return RedirectToAction("DisplayUsers");
        }

        [Authorize(Roles = "admin")]
        public ActionResult DisplayOrders(string id)
        {
            List<DisplayOrderItem> items = new List<DisplayOrderItem>();
            var ordersItems = _ctx.ItemOrder.Where(x => x.Order.UserId == id)
                                            .ToList()
                                            .Select(y =>
                                            new DisplayOrderItem
                                            (
                                                y.Pizza.Basis.Name,
                                                y.Pizza.Size.Name,
                                                y.Pizza.Sauce.Name,
                                                y.Pizza.Ingredients.Count() == 0 ? "" : y.Pizza.Ingredients.Select(z => z.Name).Aggregate((i, j) => i + ", " + j ),
                                                y.Quantity.ToString(),
                                                (y.Pizza.Price * y.Quantity * 0.95).ToString(),
                                                y.Order.OrderTime.ToString(),
                                                y.Order.ContactInfo.Name,
                                                y.Order.ContactInfo.PhoneNumber,
                                                y.Order.ContactInfo.Address
                                            ));
            return View(ordersItems);
        }
        //////////////////////////////////////////////////////////////////////////////////////BASIS CRUD
        [Authorize(Roles = "admin")]
        public ActionResult DisplayBasis()
        {
            return View(_ctx.Basis.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult CreateBasis()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult CreateBasis(Basis basis)
        {
            _ctx.Basis.Add(basis);
            _ctx.SaveChanges();
            return View("DisplayBasis", _ctx.Basis.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditBasis(int id)
        {
            return View(_ctx.Basis.SingleOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult EditBasis(Basis basis)
        {
            var oldBasis = _ctx.Basis.Find(basis.Id);
            if (oldBasis == null)
            {
                return View("DisplayBasis", _ctx.Basis.ToList());
            }
            _ctx.Entry(oldBasis).CurrentValues.SetValues(basis);
            _ctx.SaveChanges();
            return View("DisplayBasis", _ctx.Basis.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteBasis(int id)
        {
            var basis = _ctx.Basis.SingleOrDefault(x => x.Id == id);
            _ctx.Basis.Remove(basis);
            _ctx.SaveChanges();
            return View("DisplayBasis", _ctx.Basis.ToList());
        }
        //////////////////////////////////////////////////////////////////////////////////////SIZE CRUD
        [Authorize(Roles = "admin")]
        public ActionResult DisplaySizes()
        {
            return View(_ctx.Size.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult CreateSize()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult CreateSize(Size size)
        {
            _ctx.Size.Add(size);
            _ctx.SaveChanges();
            return View("DisplaySizes", _ctx.Size.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditSize(int id)
        {
            return View(_ctx.Size.SingleOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult EditSize(Size size)
        {
            var oldSize = _ctx.Size.Find(size.Id);
            if (oldSize == null)
            {
                return View("DisplaySizes", _ctx.Size.ToList());
            }
            _ctx.Entry(oldSize).CurrentValues.SetValues(size);
            _ctx.SaveChanges();
            return View("DisplaySizes", _ctx.Size.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteSize(int id)
        {
            var size = _ctx.Size.SingleOrDefault(x => x.Id == id);
            _ctx.Size.Remove(size);
            _ctx.SaveChanges();
            return View("DisplaySizes", _ctx.Size.ToList());
        }
        //////////////////////////////////////////////////////////////////////////////////////SAUCE CRUD
        [Authorize(Roles = "admin")]
        public ActionResult DisplaySauces()
        {
            return View(_ctx.Sauce.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult CreateSauce()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult CreateSauce(Sauce sauce)
        {
            _ctx.Sauce.Add(sauce);
            _ctx.SaveChanges();
            return View("DisplaySauces", _ctx.Sauce.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditSauce(int id)
        {
            return View(_ctx.Sauce.SingleOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult EditSauce(Sauce sauce)
        {
            var oldSauce = _ctx.Sauce.Find(sauce.Id);
            if (oldSauce == null)
            {
                return View("DisplaySauces", _ctx.Sauce.ToList());
            }
            _ctx.Entry(oldSauce).CurrentValues.SetValues(sauce);
            _ctx.SaveChanges();
            return View("DisplaySauces", _ctx.Sauce.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteSauce(int id)
        {
            var sauce = _ctx.Sauce.SingleOrDefault(x => x.Id == id);
            _ctx.Sauce.Remove(sauce);
            _ctx.SaveChanges();
            return View("DisplaySauces", _ctx.Sauce.ToList());
        }
        //////////////////////////////////////////////////////////////////////////////////////INGRID CRUD
        [Authorize(Roles = "admin")]
        public ActionResult DisplayIngredients()
        {
            return View(_ctx.Ingredient.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult CreateIngredient()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult CreateIngredient(Ingredient ingredient)
        {
            _ctx.Ingredient.Add(ingredient);
            _ctx.SaveChanges();
            return View("DisplayIngredients", _ctx.Ingredient.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditIngredient(int id)
        {
            return View(_ctx.Ingredient.SingleOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult EditIngredient(Ingredient ingredient)
        {
            var oldIngredient = _ctx.Ingredient.Find(ingredient.Id);
            if (oldIngredient == null)
            {
                return View("DisplayIngredients", _ctx.Ingredient.ToList());
            }
            _ctx.Entry(oldIngredient).CurrentValues.SetValues(ingredient);
            _ctx.SaveChanges();
            return View("DisplayIngredients", _ctx.Ingredient.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteIngredient(int id)
        {
            var ingredient = _ctx.Ingredient.SingleOrDefault(x => x.Id == id);
            _ctx.Ingredient.Remove(ingredient);
            _ctx.SaveChanges();
            return View("DisplayIngredients", _ctx.Ingredient.ToList());
        }
    }
}