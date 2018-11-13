using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class Order
    {
        public Order()
        {
            //User = new ApplicationUser();
            Items = new List<OrderItem>();
            ContactInfo = new ContactInfo();
        }
        public int Id { get; set; }
        //public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }
        [Required]
        public virtual ContactInfo ContactInfo { get; set; }
        [Required]
        public virtual ICollection<OrderItem> Items { get; set; }
    }
}