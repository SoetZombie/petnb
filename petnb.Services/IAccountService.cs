using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace petnb.Services
{
    public interface IAccountService
    {
        void CreatePetSitter(string userId);
        void CreatePetOwner (string userId);
    }
}
