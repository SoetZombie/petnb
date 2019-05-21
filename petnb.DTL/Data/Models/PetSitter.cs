using System.Collections.Generic;
using petnb.DTL.Models;

namespace petnb.DTL.Data.Models
{
    public class PetSitter
    {
        public int PetSitterId { get; set; }
        public List<PetSitterOffer> PetSitterOffers { get; set; } = new List<PetSitterOffer>();
        public double? Rating { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Experience Experience { get; set; }
}
}
