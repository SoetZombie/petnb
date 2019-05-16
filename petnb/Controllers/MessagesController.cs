using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petnb.Services;

namespace petnb.Controllers
{
    public class MessagesController : Controller
    {
    private readonly IFirebaseService _firebaseService;

        public MessagesController(IFirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }
        public async Task<IActionResult> Index()
        {
            var checkToken = HttpContext.Session.GetString("FirebaseToken");

            if (checkToken == null)
            {
                var customToken = await _firebaseService.GenerateCustomToken("test");
                HttpContext.Session.SetString("FirebaseToken", customToken);
            }
            

            return View();

        }
    }
}