using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public class Product
    {
        public long Id { get; set; } 
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
