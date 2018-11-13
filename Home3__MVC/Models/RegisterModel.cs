using System;
using System.ComponentModel.DataAnnotations;

namespace Home3__MVC.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please enter email")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" +
            @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$",
            ErrorMessage = "Email isn`t valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password isn`t valid")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password isn`t match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [RegularExpression(@"\w+", ErrorMessage = "Please use only letters, numbers and underscore symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [RegularExpression(@"\+380\d{9}", ErrorMessage = "Phone number is not valid. Example: +380XX-XX-XX-XXX")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"Rivne, \w+, \w+|/", ErrorMessage = "Address is not valid. Example: Rivne, Street name, Building number")]
        public string Address { get; set; }
    }
}