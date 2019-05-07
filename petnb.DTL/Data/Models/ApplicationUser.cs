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

        public List<Pet> Pets { get; set; } = new List<Pet>();
        public bool IsPetSitter { get; set; }
        public string FullName { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();

        public double? Rating { get; set; }
        public string Address { get; set; }
        //public bool Email { get; set; } ?
        public int? Age { get; set; }
        
    }
    //
}
