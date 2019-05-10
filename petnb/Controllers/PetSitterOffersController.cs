using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using petnb.DTL.Data;
using petnb.DTL.Data.Models;
using petnb.Models;

namespace petnb.Controllers
{
    public class PetSitterOffersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PetSitterOffersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PetSitterOffers
        public async Task<IActionResult> Index()
        {
            return View(await _context.PetSitterOffer.ToListAsync());
        }

        // GET: PetSitterOffers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petSitterOffer = await _context.PetSitterOffer
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
        public async Task<IActionResult> Create([Bind("PetSitterOfferId,Heading,Content,Location,PetType,PetBreed,StartOfSit,EndOfSit")] PetSitterOffer petSitterOffer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petSitterOffer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petSitterOffer);
        }

        // GET: PetSitterOffers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petSitterOffer = await _context.PetSitterOffer.FindAsync(id);
            if (petSitterOffer == null)
            {
                return NotFound();
            }
            return View(petSitterOffer);
        }

        // POST: PetSitterOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetSitterOfferId,Heading,Content,Location,PetType,PetBreed,StartOfSit,EndOfSit")] PetSitterOffer petSitterOffer)
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
            return View(petSitterOffer);
        }

        // GET: PetSitterOffers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petSitterOffer = await _context.PetSitterOffer
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
            var petSitterOffer = await _context.PetSitterOffer.FindAsync(id);
            _context.PetSitterOffer.Remove(petSitterOffer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetSitterOfferExists(int id)
        {
            return _context.PetSitterOffer.Any(e => e.PetSitterOfferId == id);
        }
    }
}
