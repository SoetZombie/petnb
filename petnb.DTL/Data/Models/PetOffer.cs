using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petnb.DTL.Data.Models;
using petnb.DTL.Models;

namespace petnb.DTL.Models
{
    public class PetOffer
    {
        public int PetOfferId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public decimal? Reward { get; set; }
        public string PetLocation { get; set; }
        public string PetNeeds { get; set; }
        public DateTime StartOfSit { get; set; }
        public DateTime EndOfSit { get; set; }
        public ApplicationUser User { get; set; }
        public Pet Pet { get; set; }

    }
}
