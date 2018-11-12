using Home3__MVC.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class HomeViewModel
    {
        public HomeViewModel(List<Basis> basis, List<Size> sizes, List<Sauce> sauces, List<Ingredient> ingredients)
        {
            Basis = basis;
            Sizes = sizes;
            Sauces = sauces;
            Ingredients = ingredients;
            Order = new Order();
        }
        public Order Order { get; set; }
        public List<Basis> Basis { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Sauce> Sauces { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}