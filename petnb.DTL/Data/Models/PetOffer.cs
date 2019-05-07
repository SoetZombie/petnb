using petnb.DTL.Data.Models;
using petnb.DTL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petnb.Data.Models
{
    public class PetOffer
    {
        //variables
        private Pet pet;
        private ApplicationUser user;
        private Pet _pet;

        //properties
        public int PetOfferId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public decimal Reward { get; set; }
        public string PetLocation { get; set; }
        public string PetNeeds { get; set; }
        public DateTime StartOfSit { get; set; }
        public DateTime EndOfSit { get; set; }
        public ApplicationUser User { get; set; }
        public Pet Pet { get => _pet; set => _pet = value; }

    }
}
