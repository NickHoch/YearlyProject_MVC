using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models.DbModels
{
    public class Pizza
    {
        public Pizza()
        {
            ItemOrders = new List<ItemOrder>();
            Ingredients = new List<Ingredient>();
        }
        public Pizza(Basis basis, Size size, Sauce sauce, List<Ingredient> ingredients, double weight, double price)
        {
            Basis = basis;
            Size = size;
            Sauce = sauce;
            Ingredients = ingredients;
            Weight = weight;
            Price = price;
            ItemOrders = new List<ItemOrder>();
        }
        public int Id { get; set; }
        public virtual Basis Basis { get; set; }
        public virtual Size Size { get; set; }
        public virtual Sauce Sauce { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public virtual ICollection<ItemOrder> ItemOrders { get; set; }
    }
}