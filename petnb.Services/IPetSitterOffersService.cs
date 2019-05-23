using System;

namespace petnb.Services
{
    public interface IPetSitterOffersService
    {
        void Create(string heading, string content, DateTime startOfSit, DateTime endOfSit, int expectedSalary,
            string salaryExplanation, int zipCode, bool dog, bool cat, bool bird, bool fish, bool reptile, bool hamster,
            int availableToDrive, string userId);
    }
}