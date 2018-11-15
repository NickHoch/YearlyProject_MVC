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
            Items = new List<OrderItem>();
            ContactInfo = new ContactInfo();
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime OrderTime { get; set; }
        [Required]
        public virtual ContactInfo ContactInfo { get; set; }
        [Required]
        public virtual ICollection<OrderItem> Items { get; set; }
    }
}