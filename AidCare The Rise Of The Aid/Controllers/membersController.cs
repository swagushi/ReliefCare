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
    public class membersController : Controller
    {
        private readonly AidCareContext _context;

        public membersController(AidCareContext context)
        {
            _context = context;
        }

        // GET: members
        public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var members = from s in _context.member
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    members = members.OrderByDescending(s => s.LastName);
                    break;
                    members = members.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<member>.CreateAsync(members.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
  
        // GET: members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.member  == null)
            {
                return NotFound();
            }

            var member = await _context.member
                .FirstOrDefaultAsync(m => m.memberId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("memberId,FirstName,LastName,DateTime")] member member)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.member == null)
            {
                return NotFound();
            }

            var member = await _context.member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("memberId,FirstName,LastName,DateTime")] member member)
        {
            if (id != member.memberId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!memberExists(member.memberId))
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
            return View(member);
        }

        // GET: members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.member == null)
            {
                return NotFound();
            }

            var member = await _context.member
                .FirstOrDefaultAsync(m => m.memberId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.member == null)
            {
                return Problem("Entity set 'AidCareContext.member'  is null.");
            }
            var member = await _context.member.FindAsync(id);
            if (member != null)
            {
                _context.member.Remove(member);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool memberExists(int id)
        {
          return (_context.member?.Any(e => e.memberId == id)).GetValueOrDefault();
        }
    }
}
