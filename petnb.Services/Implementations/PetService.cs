using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using petnb.DTL.Data;
using petnb.DTL.Data.Models.Enums;
using petnb.DTL.Models;

namespace petnb.Services.Implementations
{
    //TODO: Finish this and also interface for this service
    public class PetService: IPetService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public PetService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async void Create(int petAge, double petDifficulty, string petName, double petWeight, PetTypeEnum petType, string petBreed, string userId)
        {
            var user = _context.Users
                .Include(p => p.Pets)
                .FirstOrDefault(i => i.Id == userId);
            if(user != null) { 
            var pet = new Pet
            {
                PetWeight = petWeight,
                PetType = petType,
                PetAge = petAge,
                PetName = petName,
                PetBreed = petBreed,
                PetDifficulty = petDifficulty
            };
            if (!user.IsPetOwner)
            {
                user.IsPetOwner = true;
            }
            user.Pets.Add(pet);
            _context.Add(pet);
            await _context.SaveChangesAsync();
            }
            else
            {
                throw new NullReferenceException();
            }


        }

        public async Task<List<Pet>> AllPets()
        {
            return await _context.Pets.ToListAsync();
        }
    }
}
