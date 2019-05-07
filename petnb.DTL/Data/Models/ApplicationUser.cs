using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using petnb.DTL.Data.Models;

namespace petnb.DTL.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public bool IsPetOwner { get; set; }
        public bool IsPetSitter { get; set; }
        public string FullName { get; set; }
        public double Rating { get; set; }
        public List<Review> Review { get; set; }
        public string Adress { get; set; }
        //public bool Email { get; set; } set in core values
        public int Age { get; set; }
        public Pet Pet { get; set; }
        public Review Review { get; set; }

    }
}
