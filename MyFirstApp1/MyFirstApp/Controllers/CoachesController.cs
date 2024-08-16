using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsAcademy.Data;
using SportsAcademy.Models;

namespace SportsAcademy.Controllers
{
    public class CoachesController : Controller
    {
        private readonly AppDbContext _context;

        public CoachesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Coaches
        public async Task<IActionResult> Index()
        {
              return _context.Coachs != null ? 
                          View(await _context.Coachs.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Coachs'  is null.");
        }

        public async Task<IActionResult> Index3()
        {
            return _context.Coachs != null ?
                        View(await _context.Coachs.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Coachs'  is null.");
        }

        // GET: Coaches/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Coachs == null)
            {
                return NotFound();
            }

            var coach = await _context.Coachs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }

        // GET: Coaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,MiddleName,Country,Gender,PreviousOrganizationExperience,StartTime,EndTime,Salary")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                coach.Id = Guid.NewGuid();
                _context.Add(coach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
        }

        // GET: Coaches/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Coachs == null)
            {
                return NotFound();
            }

            var coach = await _context.Coachs.FindAsync(id);
            if (coach == null)
            {
                return NotFound();
            }
            return View(coach);
        }

        // POST: Coaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,LastName,MiddleName,Country,Gender,PreviousOrganizationExperience,StartTime,EndTime,Salary")] Coach coach)
        {
            if (id != coach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachExists(coach.Id))
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
            return View(coach);
        }

        // GET: Coaches/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Coachs == null)
            {
                return NotFound();
            }

            var coach = await _context.Coachs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coach == null)
            {
                return NotFound();
            }

            return View(coach);
        }

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Coachs == null)
            {
                return Problem("Entity set 'AppDbContext.Coachs'  is null.");
            }
            var coach = await _context.Coachs.FindAsync(id);
            if (coach != null)
            {
                _context.Coachs.Remove(coach);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoachExists(Guid id)
        {
          return (_context.Coachs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
