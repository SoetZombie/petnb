using petnb.DTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace petnb.DTL.Data.Models
{
    public class PetSitterOffer
    {
        //properties
        public int PetSitterOfferId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
        public string PetType { get; set; }
        //   public string PetBreed { get; set; }
        public DateTime StartOfSit { get; set; }
        public DateTime EndOfSit { get; set; }
        public PetSitter PetSitter { get; set; }
        public int ExpectedSalary { get; set; }
        public int PetSitterId { get; set; }
    }
}
