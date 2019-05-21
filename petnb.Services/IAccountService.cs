using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using petnb.DTL.Data.Models.Enums;

namespace petnb.Services
{
    public interface IAccountService
    {
        void CreatePetSitter(string userId);
        void CreatePetOwner (string userId);
        void FillProfile(string userId, string fullname, DateTime birthdate, string street, int zipcode, byte[] profileImage, bool wasPetSitter, PetSitterExperienceEnum petSitterExperienceEnum, string petSitterExperience, string bio);
    }
}
