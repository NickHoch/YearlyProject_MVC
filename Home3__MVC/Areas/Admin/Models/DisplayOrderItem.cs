using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Areas.Admin.Models
{
    public class DisplayOrderItem
    {
        public DisplayOrderItem() { }
        public DisplayOrderItem(string basis, string size, string sauce, string ingredients, string quantity, string price, string orderTime, string name, string phoneNumber, string address)
        {
            Basis = basis;
            Size = size;
            Sauce = sauce;
            Ingredients = ingredients;
            Quantity = quantity;
            Price = price;
            OrderTime = orderTime;
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        public string Basis { get; set; }
        public string Size { get; set; }
        public string Sauce { get; set; }
        public string Ingredients { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string OrderTime { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}