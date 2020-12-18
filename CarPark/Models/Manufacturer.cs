using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarPark.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name field is required.")]
        [StringLength(35, ErrorMessage ="Name must be with a maximum characters of 35.")]
        public string Name { get; set; }
       
       // [RegularExpression(@"^[A-Z][A-Za-z]{2,35}\d{1,4}(-\d{1,4})?,[A-Z][A-Za-z]{2,35}", ErrorMessage = "Needed format of address e.g. Victoriastrase 231, Munich")]
        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [Range(1900, int.MaxValue)]
        public int? FoundationYear { get; set; }  
    }
}