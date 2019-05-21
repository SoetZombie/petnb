using System;
using System.Threading.Tasks;
using petnb.DTL.Data;
using petnb.DTL.Data.Models;
using petnb.DTL.Data.Models.Enums;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace petnb.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
       
        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void CreatePetSitter(string userId)
        {
            var petSitter = new PetSitter
            {
                UserId = userId
            };
            _context.PetSitters.Add(petSitter);
            await _context.SaveChangesAsync();
        }

    public void CreatePetOwner(string userId)
        {
            //
            throw new System.NotImplementedException();
        }

        public async void FillProfile(string userId, string fullname, DateTime birthdate, string street, int zipcode, byte[] profileImage, bool wasPetSitter, PetSitterExperienceEnum petSitterExperienceEnum, string petSitterExperience, string bio)
        {
            var user = _context.Users.Include(p => p.PetSitter)
                .ThenInclude(p => p.Experience)
                .FirstOrDefault(p => p.Id == userId);

            user.BirthDate = birthdate;
            user.Address = street;
            user.Zipcode = zipcode;
            user.Bio = bio;
            //user.ProfilePicture = profileImage;

            var experience = new Experience { WasPetsitter = wasPetSitter, PetsitterExperience = petSitterExperience, PetSitterExperienceEnum = petSitterExperienceEnum };
            var petsitter = user.PetSitter;
            petsitter.Experience = experience;
            _context.Update(user);
            await _context.SaveChangesAsync();


                
                //FirstOrDefault(p => p.Id == userId).
        }
    }
}