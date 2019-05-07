using petnb.DTL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace petnb.DTL.Data.Models
{
    public class Pet
    {
        //properties
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int PetType { get; set; }
        public string PetBreed { get; set; }
        public int Age { get; set; }
        public double Difficulty { get; set; }
        public double Weight { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
