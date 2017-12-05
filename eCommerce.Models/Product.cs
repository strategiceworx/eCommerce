using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [MaxLength(255)]
        public string ImageUrl { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal CostPrice { get; set; }

    }
}
