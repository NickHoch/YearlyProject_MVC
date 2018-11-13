using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class Basis : Basic
    {
        public Basis() { }
        public Basis(double coefficient, string name)
        {
            Coefficient = coefficient;
            Name = name;
        }
        public double Coefficient { get; set; }
    }
}