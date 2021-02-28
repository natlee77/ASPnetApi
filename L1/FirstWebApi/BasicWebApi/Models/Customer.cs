using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BasicWebApi.Models
{
    public class Customer
    {
               

        public Guid Id { get; set; }



     
        [Column(TypeName = "nvarchar(50)")]
        public string CompanyName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        public string DisplayName => $"{FirstName }  {LastName }";

    }
}
