using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression(@"\w+", ErrorMessage = "Please use only letters, numbers and underscore symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [RegularExpression(@"\+380\d{9}", ErrorMessage = "Phone number is not valid. Example: +380XX-XX-XX-XXX")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        [RegularExpression(@"Rivne, \w+, \w+", ErrorMessage = "Address is not valid. Example: Rivne, Street name, Building number")]
        public string Address { get; set; }
        [Required]
        public virtual ICollection<Order> Orders { get; set; }
    }
}