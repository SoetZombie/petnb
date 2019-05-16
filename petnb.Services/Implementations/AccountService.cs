using System.Threading.Tasks;
using petnb.DTL.Data;
using petnb.DTL.Data.Models;

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
    }
}