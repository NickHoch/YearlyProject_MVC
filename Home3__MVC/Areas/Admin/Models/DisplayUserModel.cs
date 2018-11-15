using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Areas.Admin.Models
{
    public class DisplayUserModel
    {
        public DisplayUserModel(string id, string email, string phoneNumber, string name, string address)
        {
            Id = id;
            Email = email;
            PhoneNumber = phoneNumber;
            Name = name;
            Address = address;
        }
        public string Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}