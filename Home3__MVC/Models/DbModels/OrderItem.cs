using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class OrderItem
    {
        public OrderItem() { }
        public OrderItem(int id, int quantity, Pizza pizza)
        {
            Id = id;
            Quantity = quantity;
            Pizza = pizza;
        }
        public int Id { get; set; }
        public int Quantity { get; set; }
        [Required]
        public virtual Pizza Pizza { get; set; }
        [Required]
        public virtual Order Order { get; set; }
    }
}