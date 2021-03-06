﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using petnb.DTL.Models;

namespace petnb.DTL.Data.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public bool IsPetOwner { get; set; }

        public List<Pet> Pets { get; set; } = new List<Pet>();
        public string FullName { get; set; }
        public byte[] ProfilePicture { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public string Bio { get; set; }
        public PetSitter PetSitter { get; set; }
        public double? Rating { get; set; }
        public string Address { get; set; }
        public int? Zipcode { get; set; }
        public DateTime BirthDate { get; set; }
        //public bool Email { get; set; } ?
        public int? Age { get; set; }
        public bool FilledProfile { get; set; }

    }
    //
}
