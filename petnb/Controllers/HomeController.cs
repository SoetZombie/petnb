using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;/**//**/
using petnb.Models;

using Microsoft.AspNetCore.Identity;
using petnb.DTL.Data.Models;
using petnb.DTL.Models;
using petnb.Models.ManageViewModels;

namespace petnb.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }



        public IActionResult Index()
        {
           return View();/**/
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            return RedirectToAction("Index", "PetSitterOffers", new {id = model.ZipCode});
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult BecomePetSitter()
        {

            return RedirectToAction("Create", "PetSitterOffers");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
