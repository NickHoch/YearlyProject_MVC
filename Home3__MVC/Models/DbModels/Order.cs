using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class Order
    {
        public Order()
        {
            User = new ApplicationUser();
            Items = new List<ItemOrder>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<ItemOrder> Items { get; set; }
    }
}