using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using petnb.DTL.Data.Models;

namespace petnb.Models.PetSitterOfferViewModels
{
    public class PetSitterOfferViewModel
    {
        public List<PetType> PetsToSit { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public int Address { get; set; }
        public DateTime StartOfSit { get; set; }
        public DateTime EndOfSit { get; set; }
       // public PetSitterExperienceEnum PetSitterExperienceEnum { get; set; }
        public int ExpectedSalary { get; set; }
        public string SalaryExplanation { get; set; }
    }
}
