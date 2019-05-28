using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using petnb.DTL.Data;
using petnb.DTL.Data.Models;
using petnb.DTL.Models;
using petnb.Models.AccountViewModels;
using petnb.Models.PetSitterOfferViewModels;
using petnb.Services;

namespace petnb.Controllers
{
    [Authorize]
    public class PetSitterOffersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPetSitterOffersService _petSitterOffersService;

       
        public PetSitterOffersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IPetSitterOffersService petSitterOffersService)
        {
            _context = context;
            _userManager = userManager;
            _petSitterOffersService = petSitterOffersService;
        }
        // GET: PetSitterOffers

        //[ActionName("MyOverloadedName")]
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.PetSitterOffers.Include(p => p.PetSitter);
        //    return View(await applicationDbContext.ToListAsync());
        //}.
        [AllowAnonymous]
        public async Task<IActionResult> Index(int? zipcode)
        {
  
            if (zipcode == null)
            {
                var applicationDbContext = _context.Users.Include(o => o.PetSitter).ThenInclude(o => o.PetSitterOffers).Where(o => o.PetSitter.PetSitterOffers.Count != 0).ToList();

                return View(applicationDbContext);
            }

            var allOffers = _context.Users.Include(o => o.PetSitter).ThenInclude(o => o.PetSitterOffers).Where(k => k.PetSitter.PetSitterOffers.Count != 0).ToList();
            var usersToSend = new List<ApplicationUser>();
            var listToSend= new List<PetSitterOffer>();

            foreach (var item in allOffers)
                {
                    var offers = item.PetSitter.PetSitterOffers;
                    listToSend = offers.Where(o => o.ZipCode == zipcode).ToList();
                    if (listToSend.Count != 0)
                    {
                        item.PetSitter.PetSitterOffers = listToSend;
                        usersToSend.Add(item);

                    }
                }        

            if(usersToSend.Count == 0) 
            {
  
                var searchZip = new decimal((int) zipcode);
                searchZip =  Math.Round((searchZip / 1000) * 1000);
                foreach (var item in allOffers)
                {
                    var offers = item.PetSitter.PetSitterOffers;
                    listToSend = offers.Where(o => o.ZipCode >= (searchZip-1000) && o.ZipCode <= (searchZip+1000)).ToList();
                    item.PetSitter.PetSitterOffers = listToSend;
                    if (listToSend.Count != 0)
                    {

                    usersToSend.Add(item);
                    }
                    


                }

            }

            return View(usersToSend);

        }

        // GET: PetSitterOffers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petSitterOffer = await _context.PetSitterOffers
                .Include(p => p.PetSitter)
                .FirstOrDefaultAsync(m => m.PetSitterOfferId == id);
            if (petSitterOffer == null)
            {
                return NotFound();
            }

            return View(petSitterOffer);
        }

        // GET: PetSitterOffers/Create
        
        public IActionResult Create()
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == _userManager.GetUserId(HttpContext.User));
            if (!user.FilledProfile)
            {
                TempData["CompleteProfile"] = "Please complete your profile to be able to make pet sitter offers";
                TempData.Keep("CompleteProfile");
                return RedirectToAction("AccountCompletion", "Account");
            }   
            return View();
        }

        // POST: PetSitterOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetSitterOfferViewModel model)
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (ModelState.IsValid)
            {
                _petSitterOffersService.Create(model.Heading, model.Content, model.StartOfSit, model.EndOfSit, model.ExpectedSalary, model.SalaryExplanation,model.ZipCode, model.Dog, model.Cat, model.Bird,model.Fish,model.Reptile,model.Hamster, model.AvailableToDrive, userId);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: PetSitterOffers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petSitterOffer = await _context.PetSitterOffers.FindAsync(id);
            if (petSitterOffer == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", petSitterOffer.PetSitterId);
            return View(petSitterOffer);
        }

        // POST: PetSitterOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetSitterOfferId,Heading,Content,Location,StartOfSit,EndOfSit,ExpectedSalary,UserId")] PetSitterOffer petSitterOffer)
        {
            if (id != petSitterOffer.PetSitterOfferId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petSitterOffer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetSitterOfferExists(petSitterOffer.PetSitterOfferId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", petSitterOffer.PetSitterId);
            return View(petSitterOffer);
        }

        // GET: PetSitterOffers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petSitterOffer = await _context.PetSitterOffers
                .Include(p => p.PetSitter)
                .FirstOrDefaultAsync(m => m.PetSitterOfferId == id);
            if (petSitterOffer == null)
            {
                return NotFound();
            }

            return View(petSitterOffer);
        }

        // POST: PetSitterOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petSitterOffer = await _context.PetSitterOffers.FindAsync(id);
            _context.PetSitterOffers.Remove(petSitterOffer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetSitterOfferExists(int id)
        {
            return _context.PetSitterOffers.Any(e => e.PetSitterOfferId == id);
        }
    }
}
