using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace L4_3_WebApi_Identity.Models
{
    public class User
    {
        public User()
        {

        }
        public User(string firstName, string lastName, string email )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
           
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required]



        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }
        //-->skapa DB





        //++
        public void CreatePasswordHash(string password)//används i userscontroller
        {//varja  user ska ha egna saltning
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(PasswordSalt+password));//skapa HASH from salted password
            }
        }


        //public bool ValidatePasswordHash(string password)
        //{
        //    using (var hmac = new HMACSHA512(PasswordSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        for (int i = 0; i < computedHash.Length; i++)
        //        {
        //            if (computedHash[i] != PasswordHash[i])
        //                return false;
        //        }
        //    }

        //    return true;
        //}
    }
}

 
