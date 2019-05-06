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

        //properties
        public int PetOfferId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public decimal Reward { get; set; }
        public string PetLocation { get; set; }
        public string PetNeeds { get; set; }
        public DateTime StartOfSit { get; set; }
        public DateTime EndOfSit { get; set; }
        public ApplicationUser User
        {
            get
            {
                return user;
            }
            set
            {
                if (value != null)
                {
                    user = value;
                }
            }
        }
        public Pet Pet
        {
            get
            {
                return pet;
            }
            set
            {
                if (value != null)
                {
                    pet = value;
                }
            }
        }

        //Constructor
        public PetOffer()
        {
           
        }

        public PetOffer(int petOfferId, string heading, string content, decimal reward, string petLocation, string petNeeds, DateTime startOfSit, DateTime endOfSit, ApplicationUser user, Pet pet)
        {
            PetOfferId   = petOfferId;
            Heading = heading;
            Content = content;
            Reward = reward;
            PetLocation = petLocation;
            PetNeeds = petNeeds;
            StartOfSit = startOfSit;
            EndOfSit = endOfSit;
            User = user;
            Pet = pet;
        }
    }
}
