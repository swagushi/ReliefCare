using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AidCare_The_Rise_Of_The_Aid.Areas.Identity.Data;
using AidCare_The_Rise_Of_The_Aid.Models;

namespace AidCare_The_Rise_Of_The_Aid.Views
{
    public class protestsController : Controller
    {
        private readonly AidCareContext _context;

        public protestsController(AidCareContext context)
        {
            _context = context;
        }

        // GET: protests
        public async Task<IActionResult> Index()
        {
              return _context.protest != null ? 
                          View(await _context.protest.ToListAsync()) :
                          Problem("Entity set 'AidCareContext.protest'  is null.");
        }

        // GET: protests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.protest == null)
            {
                return NotFound();
            }

            var protest = await _context.protest
                .FirstOrDefaultAsync(m => m.protestId == id);
            if (protest == null)
            {
                return NotFound();
            }

            return View(protest);
        }

        // GET: protests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: protests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("protestId,ProtestName,ProtestLocation,DateTime")] protest protest)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(protest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(protest);
        }

        // GET: protests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.protest == null)
            {
                return NotFound();
            }

            var protest = await _context.protest.FindAsync(id);
            if (protest == null)
            {
                return NotFound();
            }
            return View(protest);
        }

        // POST: protests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("protestId,ProtestName,ProtestLocation,DateTime")] protest protest)
        {
            if (id != protest.protestId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(protest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!protestExists(protest.protestId))
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
            return View(protest);
        }

        // GET: protests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.protest == null)
            {
                return NotFound();
            }

            var protest = await _context.protest
                .FirstOrDefaultAsync(m => m.protestId == id);
            if (protest == null)
            {
                return NotFound();
            }

            return View(protest);
        }

        // POST: protests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.protest == null)
            {
                return Problem("Entity set 'AidCareContext.protest'  is null.");
            }
            var protest = await _context.protest.FindAsync(id);
            if (protest != null)
            {
                _context.protest.Remove(protest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool protestExists(int id)
        {
          return (_context.protest?.Any(e => e.protestId == id)).GetValueOrDefault();
        }
    }
}
