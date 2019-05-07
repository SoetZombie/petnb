﻿using System;
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
        public bool IsPetSitter { get; set; }
        public string FullName { get; set; }
        public double Rating { get; set; }
        public string Adress { get; set; }
        //public bool Email { get; set; } set in core values
        public int Age { get; set; }

    }
}
