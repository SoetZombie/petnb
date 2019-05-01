using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petnb.Data.Models
{
    public class PetOffer
    {
        public int PetOfferId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
       // public Pet Pet
       // public User user
       public decimal Reward { get; set; }
       public DateTime StartOfSit { get; set; }
       public DateTime EndOfSit { get; set; }
    }
}
