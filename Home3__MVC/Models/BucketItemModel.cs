using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Home3__MVC.Models
{
    public class BucketItemModel
    {
        public int basisId { get; set; }
        public int sauceId { get; set; }
        public int sizeId { get; set; }
        public List<int> ingridIds { get; set; }
        public int quantity { get; set; }
        public double weight { get; set; }
        public double price { get; set; }
    }
}