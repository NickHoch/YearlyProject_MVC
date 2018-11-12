using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models.DbModels
{
    public class Sauce : Basic
    {
        public Sauce() { }
        public Sauce(double price, string name)
        {
            Price = price;
            Name = name;
        }
        public double Price { get; set; }
    }
}