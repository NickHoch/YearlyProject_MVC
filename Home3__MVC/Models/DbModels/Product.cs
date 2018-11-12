﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class Product
    {
        public Product() { }
        public Product(string name, int price, string description, string urlImage)
        {
            Name = name;
            Price = price;
            Description = description;
            UrlImage = urlImage;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string UrlImage { get; set; }
        public virtual ICollection<ItemOrder> ItemOrders { get; set; }
    }
}