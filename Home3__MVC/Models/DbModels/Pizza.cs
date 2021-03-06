﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class Pizza
    {
        public Pizza()
        {
            ItemOrders = new List<OrderItem>();
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
            ItemOrders = new List<OrderItem>();
        }
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        [Required]
        public virtual Basis Basis { get; set; }
        [Required]
        public virtual Size Size { get; set; }
        [Required]
        public virtual Sauce Sauce { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        [Required]
        public virtual ICollection<OrderItem> ItemOrders { get; set; }
    }
}