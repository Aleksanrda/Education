using System;
using System.ComponentModel.DataAnnotations;

namespace ProductList.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Count { get; set; }

        [Display(Name="Type of measure")]
        public MeasureType Measure { get; set; }
    }
}
