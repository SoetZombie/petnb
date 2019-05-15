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

namespace petnb.Controllers
{
    [Authorize]
    public class PetSitterOffersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

       
        public PetSitterOffersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: PetSitterOffers
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PetSitterOffers.Include(p => p.PetSitter);
            return View(await applicationDbContext.ToListAsync());
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
            
            return View();
        }

        // POST: PetSitterOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetSitterOffer model)
        {
            var user = _context.Users
                .Include(p => p.Pets)
                .FirstOrDefault(i => i.Id == _userManager.GetUserId(HttpContext.User));

            if (ModelState.IsValid)
            {
                var offer = new PetSitterOffer
                {
                    Heading = model.Heading,
                    Content = model.Content,
                    Location = model.Location,
                    StartOfSit = model.StartOfSit,
                    EndOfSit = model.EndOfSit,
                    ExpectedSalary = model.ExpectedSalary,
                    PetSitterId = user.PetSitter.PetSitterId
                };
                
                _context.Add(offer);
                _context.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
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
