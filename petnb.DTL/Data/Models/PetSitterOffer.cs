﻿using petnb.DTL.Models;
using System;
using System.Collections.Generic;
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
        public int PetType { get; set; }
        public string PetBreed { get; set; }
        public DateTime StartOfSit { get; set; }
        public DateTime EndOfSit { get; set; }
        public ApplicationUser User { get; set; }
    }
}