using System;
using System.Threading.Tasks;

namespace petnb.Services
{
    public interface IFirebaseService
    {
        void CreateFirebase(string credentials);
        Task<string> GenerateCustomToken(string userId);
    }
}
