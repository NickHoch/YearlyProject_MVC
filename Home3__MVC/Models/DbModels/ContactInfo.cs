using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}