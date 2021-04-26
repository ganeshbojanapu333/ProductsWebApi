using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebApi.Models
{
    public class Product
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public string description { get; set; }
        public string category { get; set; }

        [DataType(DataType.Currency)]
        public float? price { get; set; }
        public int quantity { get; set; }
    }

}
