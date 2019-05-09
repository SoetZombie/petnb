using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace petnb.Services.Implementations
{
    public class FirebaseService: IFirebaseService
    {
        public FirebaseService(string credentials)
        {
            CreateFirebase(credentials);
        }
        public void CreateFirebase(string credentials)
        {
            var firebaseAdminCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(credentials));
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromJson(firebaseAdminCredentials),

            });
        }

        public async Task<string> GenerateCustomToken(string userId)
        {
            return await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(userId);
        }
    }
}
