using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using petnb.DTL.Data.Models.Enums;
namespace petnb.Models.AccountViewModels
{
    public class AccountCompletionViewModel
    {
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Street { get; set; }
        public int Zipcode { get; set; }
        public IFormFile ProfileImage { get; set; }
        public bool WasPetSitter { get; set; }
        public PetSitterExperienceEnum PetSitterExperienceEnum { get; set; }
        public string PetSitterExperience { get; set; }
        public string Bio { get; set; }
    }
}
