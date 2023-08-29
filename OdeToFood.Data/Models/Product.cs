using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Type of food")]
        public ProductType Property { get; set; }
    }
}
