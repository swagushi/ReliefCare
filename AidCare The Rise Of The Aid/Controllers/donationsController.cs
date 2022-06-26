using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AidCare_The_Rise_Of_The_Aid.Areas.Identity.Data;
using AidCare_The_Rise_Of_The_Aid.Models;

namespace AidCare_The_Rise_Of_The_Aid.Controllers
{
    public class donationsController : Controller
    {
        private readonly AidCareContext _context;

        public donationsController(AidCareContext context)
        {
            _context = context;
        }

        // GET: donations
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var donations = from s in _context.donation
                            select s;
            switch (sortOrder)
            {
                case "name_desc":
                    donations = donations.OrderByDescending(s => s.DonationDescription);
                    break;
                case "Date":
                    donations = donations.OrderBy(s => s.DonationAmount);
                    break;
                case "date_desc":
                    donations = donations.OrderByDescending(s => s.DonationDescription);
                    break;
                default:
                    donations = donations.OrderBy(s => s.DonationAmount);
                    break;
            }
            return View(await donations.AsNoTracking().ToListAsync());
        }

        // GET: donations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.donation == null)
            {
                return NotFound();
            }

            var donation = await _context.donation
                .FirstOrDefaultAsync(m => m.donationId == id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        // GET: donations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("donationId,DonationDescription,DonationAmount")] donation donation)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(donation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donation);
        }

        // GET: donations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.donation == null)
            {
                return NotFound();
            }

            var donation = await _context.donation.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }
            return View(donation);
        }

        // POST: donations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("donationId,DonationDescription,DonationAmount")] donation donation)
        {
            if (id != donation.donationId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(donation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!donationExists(donation.donationId))
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
            return View(donation);
        }

        // GET: donations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.donation == null)
            {
                return NotFound();
            }

            var donation = await _context.donation
                .FirstOrDefaultAsync(m => m.donationId == id);
            if (donation == null)
            {
                return NotFound();
            }

            return View(donation);
        }

        // POST: donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.donation == null)
            {
                return Problem("Entity set 'AidCareContext.donation'  is null.");
            }
            var donation = await _context.donation.FindAsync(id);
            if (donation != null)
            {
                _context.donation.Remove(donation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool donationExists(int id)
        {
          return (_context.donation?.Any(e => e.donationId == id)).GetValueOrDefault();
        }
    }
}
