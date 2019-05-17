using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using petnb.DTL.Data.Models.Enums;
using petnb.DTL;
using petnb.DTL.Models;

namespace petnb.Services
{
    public interface IPetService
    {

        void Create(int petAge, double petDifficulty, string petName, double petWeight, PetTypeEnum petType, string petBreed, string userId);

        Task<List<Pet>>  AllPets();
    }
}
