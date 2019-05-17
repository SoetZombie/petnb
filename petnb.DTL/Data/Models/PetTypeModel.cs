using System;
using System.Collections.Generic;
using System.Text;
using petnb.DTL.Data.Models.Enums;

namespace petnb.DTL.Data.Models
{
    public class PetTypeModel
    {
        public int PetTypeModelId { get; set; }
        public PetTypeEnum PetTypeEnum { get; set; }
        public List<PetSitterOfferPetTypeModel> PetSitterOfferPetTypeModels { get; set; }
    }
}
