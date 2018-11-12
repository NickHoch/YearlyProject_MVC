using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models.DbModels
{
    public class Size : Basic
    {
        public Size() { }
        public Size(double weight, string name)
        {
            Weight = weight;
            Name = name;
        }
        public double Weight { get; set; }
    }
}