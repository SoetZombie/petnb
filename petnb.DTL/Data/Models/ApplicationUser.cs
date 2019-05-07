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
        public bool IsPetOwner { get; set; }

        public List<Pet> Pets { get; set; } = new List<Pet>();
        ////
        //// 
    }
    //
}
