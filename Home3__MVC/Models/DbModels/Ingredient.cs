using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models.DbModels
{
    public class Ingredient : Basic
    {
        public Ingredient() { }
        public Ingredient(double price, double weight, string name)
        {
            Price = price;
            Weight = weight;
            Name = name;
        }
        public double Price { get; set; }
        public double Weight { get; set; }
    }
}