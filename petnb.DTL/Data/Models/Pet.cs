using petnb.DTL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using petnb.DTL.Data.Models.Enums;

namespace petnb.DTL.Models
{
   public class Pet
    {
        public int PetId { get; set; }
        public string PetName { get; set; }
        public PetType PetType { get; set; }
        public int PetAge { get; set; }
        public double PetDifficulty { get; set; }
        public double PetWeight { get; set; }
        public string PetBreed { get; set; }

        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
}
}
