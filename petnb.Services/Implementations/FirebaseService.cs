using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace petnb.Services.Implementations
{
    public class FirebaseService: IFirebaseService
    {
        public FirebaseService()
        {
            CreateFirebase();
        }
        public void CreateFirebase()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("wwwroot/service-account-file.json"),

            });
        }

        public async Task<string> GenerateCustomToken(string userId)
        {
            return await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(userId);
        }
    }
}
