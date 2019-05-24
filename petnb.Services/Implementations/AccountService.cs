using System;
using System.IO;
using System.Threading.Tasks;
using petnb.DTL.Data;
using petnb.DTL.Data.Models;
using petnb.DTL.Data.Models.Enums;
using System.Linq;
using Microsoft.AspNetCore.Http;
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

        public async void FillProfile(string userId, string fullName, DateTime birthdate, string street, int zipcode,  IFormFile profileImage, bool wasPetSitter, PetSitterExperienceEnum petSitterExperienceEnum, string petSitterExperience, string bio)
        {
            var user = _context.Users.Include(p => p.PetSitter)
                .ThenInclude(p => p.Experience)
                .FirstOrDefault(p => p.Id == userId);
            byte[] imageBytes = null;

            using (var ms = new MemoryStream())
            {
                profileImage.CopyTo(ms);
                imageBytes = ms.ToArray();
            }

            user.BirthDate = birthdate;
            user.Address = street;
            user.Zipcode = zipcode;
            user.Bio = bio;
            user.ProfilePicture = imageBytes;
            user.FullName = fullName;
            user.FilledProfile = true;

            var experience = new Experience { WasPetsitter = wasPetSitter, PetsitterExperience = petSitterExperience, PetSitterExperienceEnum = petSitterExperienceEnum };

            var petSitter = user.PetSitter;

            petSitter.Experience = experience;
            _context.Update(user);

            _context.SaveChanges();


                
                //FirstOrDefault(p => p.Id == userId).
        }
    }
}