using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class EditModel
    {
        [Required(ErrorMessage = "Please enter email")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" +
            @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$",
            ErrorMessage ="Email isn`t valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter old password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password isn`t valid")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password isn`t valid")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password isn`t match")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password isn`t valid")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression(@"\w+", ErrorMessage = "Please use only letters, numbers and underscore symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [RegularExpression(@"\+380\d{9}", ErrorMessage = "Phone number is not valid. Example: +380XX-XX-XX-XXX")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}