using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPark.Models
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
    }
}