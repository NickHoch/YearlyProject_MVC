using Home3__MVC.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class ItemOrder
    {
        public ItemOrder() { }
        public ItemOrder(int quantity, Pizza pizza)
        {
            Quantity = quantity;
            Pizza = pizza;
        }
        public int Id { get; set; }
        public int Quantity { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}