using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using petnb.DTL.Data.Models;
using petnb.DTL.Data.Models.Enums;

namespace petnb.Models.PetSitterOfferViewModels
{
    public class PetSitterOfferViewModel
    {
 
        [Required]
        public string Heading { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Address { get; set; }
        [Required]
        public DateTime StartOfSit { get; set; }
        [Required]
        public DateTime EndOfSit { get; set; }

        [Required]
        // public PetSitterExperienceEnum PetSitterExperienceEnum { get; set; }
        public int ExpectedSalary { get; set; }

        [Required] public string SalaryExplanation { get; set; }
        [Required] public int ZipCode { get; set; }
        [Required]
        public bool Dog { get; set; }
        public bool Cat { get; set; }
        public bool Bird { get; set; }
        public bool Fish { get; set; }
        public bool Reptile { get; set; }
        public bool Hamster { get; set; }
        public int AvailableToDrive { get; set; }
    }
}


