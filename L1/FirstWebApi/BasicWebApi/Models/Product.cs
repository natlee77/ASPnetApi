using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebApi.Models
{
    public class Product
    {
        [Key]
        [Required]

        public Guid Id { get; set; }

        [Column( TypeName ="char(13)")]
        public string EAN { get; set; }

         
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string  Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(120)")]
        public string Vendor { get; set; }

        
        [Column(TypeName = "nvarchar(120)")]
        public string ShortDescription { get; set; }

        
        [Column(TypeName = "nvarchar(max)")]
        public string LongDescription { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public double Price { get; set; }

    }
}
