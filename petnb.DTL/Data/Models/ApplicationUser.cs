using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace petnb.DTL.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public bool IsPetSitter { get; set; }
        public string FullName { get; set; }
        public double Rating { get; set; }
        public string Adress { get; set; }
        //public bool Email { get; set; } set in core values
        public int Age { get; set; }


        //Construtor
        public ApplicationUser(string name)
        {
            FullName = name;
        }

        public ApplicationUser(bool sitter, string name, double rating, string adress, int age)
        {
            IsPetSitter = sitter;
            FullName = name;
            Rating = rating;
            Adress = adress;
            Age = age;
        }
    }
}
