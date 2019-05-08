using System;
using System.Threading.Tasks;

namespace petnb.Services
{
    public interface IFirebaseService
    {
        void CreateFirebase();
        Task<string> GenerateCustomToken(string userId);
    }
}
