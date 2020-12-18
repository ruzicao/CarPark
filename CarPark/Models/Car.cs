using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarPark.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="this field is required.")]
        public string Name { get; set; }

        [StringLength(15)]
        public string Color { get; set; }
       
        [Range(2005, int.MaxValue)]
        public int Year { get; set; }
        public bool? Buy { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
    }
}