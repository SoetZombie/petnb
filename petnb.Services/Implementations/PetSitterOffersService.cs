using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using petnb.DTL.Data;
using petnb.DTL.Data.Models;
using petnb.DTL.Data.Models.Enums;

namespace petnb.Services.Implementations
{
    public class PetSitterOffersService: IPetSitterOffersService
    {
        private readonly ApplicationDbContext _context;

        public PetSitterOffersService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async void Create(string heading, string content, DateTime startOfSit, DateTime endOfSit, int expectedSalary,
            string salaryExplanation, int zipCode, bool dog, bool cat, bool bird, bool fish, bool reptile, bool hamster,
            int availableToDrive, string userId)
        {
            var user =  _context.Users
                .Include(p => p.PetSitter)
                .ThenInclude(o => o.PetSitterOffers)
                .ThenInclude(u => u.PetSitterOfferPetTypeModels)
                .FirstOrDefault(us => us.Id == userId);
            var petSitterOffer = new PetSitterOffer
            {
                Heading = heading,
                Content = content,
                StartOfSit = startOfSit,
                EndOfSit = endOfSit,
                ExpectedSalary = expectedSalary,
                SalaryExplanation = salaryExplanation,
                ZipCode = zipCode,
                AvailableToDrive = availableToDrive
            };

            var petTypes =  _context.PetTypes.ToList(); 

            //var petSitterOfferPetType = new PetSitterOfferPetTypeModel
            //{
            //    PetSitterOffer = petSitterOffer,
            //    PetTypeModel = 
            //};

            foreach (var pet in petTypes)
            {
                var petSitterOfferPetType = new PetSitterOfferPetTypeModel
                {
                    PetSitterOffer = petSitterOffer,
                    PetTypeModel = pet

                    
                };
                petSitterOffer.PetSitterOfferPetTypeModels.Add(petSitterOfferPetType);
            }

            if (!dog)
            {
                var remove =
                    petSitterOffer.PetSitterOfferPetTypeModels.FirstOrDefault(a =>
                        a.PetTypeModel.PetTypeEnum == PetTypeEnum.Dog);
                petSitterOffer.PetSitterOfferPetTypeModels.Remove(remove);
            }
            if (!cat)
            {
                var remove =
                    petSitterOffer.PetSitterOfferPetTypeModels.FirstOrDefault(a =>
                        a.PetTypeModel.PetTypeEnum == PetTypeEnum.Cat);
                petSitterOffer.PetSitterOfferPetTypeModels.Remove(remove);
            }
            if (!bird)
            {
                var remove =
                    petSitterOffer.PetSitterOfferPetTypeModels.FirstOrDefault(a =>
                        a.PetTypeModel.PetTypeEnum == PetTypeEnum.Bird);
                petSitterOffer.PetSitterOfferPetTypeModels.Remove(remove);
            }
            if (!fish)
            {
                var remove =
                    petSitterOffer.PetSitterOfferPetTypeModels.FirstOrDefault(a =>
                        a.PetTypeModel.PetTypeEnum == PetTypeEnum.Fish);
                petSitterOffer.PetSitterOfferPetTypeModels.Remove(remove);
            }
            if (!reptile)
            {
                var remove =
                    petSitterOffer.PetSitterOfferPetTypeModels.FirstOrDefault(a =>
                        a.PetTypeModel.PetTypeEnum == PetTypeEnum.Reptile);
                petSitterOffer.PetSitterOfferPetTypeModels.Remove(remove);
            }

            if (!hamster)
            {
                var remove =
                    petSitterOffer.PetSitterOfferPetTypeModels.FirstOrDefault(a =>
                        a.PetTypeModel.PetTypeEnum == PetTypeEnum.Hamster);
                petSitterOffer.PetSitterOfferPetTypeModels.Remove(remove);
            }

            user.PetSitter.PetSitterOffers.Add(petSitterOffer);
            _context.Update(user);
            _context.SaveChanges();


        }
    }
}