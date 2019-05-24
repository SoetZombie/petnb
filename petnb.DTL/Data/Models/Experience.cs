using System;
using System.Collections.Generic;
using System.Text;
using petnb.DTL.Data.Models.Enums;

namespace petnb.DTL.Data.Models
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public bool WasPetsitter { get; set; }
        public PetSitterExperienceEnum PetSitterExperienceEnum { get; set; }
        public string PetsitterExperience { get; set; }
        public PetSitter PetSitter { get; set; }
        public int PetSitterId { get; set; }
    }
}
