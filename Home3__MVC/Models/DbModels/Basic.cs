using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class Basic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}