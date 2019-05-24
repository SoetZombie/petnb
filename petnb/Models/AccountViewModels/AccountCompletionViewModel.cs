using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using petnb.DTL.Data.Models.Enums;
namespace petnb.Models.AccountViewModels
{
    public class AccountCompletionViewModel
    {
        //Required = validation
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int Zipcode { get; set; }
        [Required]
        public IFormFile ProfileImage { get; set; }
        [Required]
        public bool WasPetSitter { get; set; }
        [Required]
        public PetSitterExperienceEnum PetSitterExperienceEnum { get; set; }
        [Required]
        public string PetSitterExperience { get; set; }
        [Required]
        public string Bio { get; set; }
    }
}
