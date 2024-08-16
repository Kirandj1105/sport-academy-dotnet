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
    public class Users1Controller : Controller
    {
        private readonly AppDbContext _context;

        public Users1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: Users1
        public async Task<IActionResult> Index()
        {
              return _context.GetUsers != null ? 
                          View(await _context.GetUsers.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.GetUsers'  is null.");
        }

        public async Task<IActionResult> Index2()
        {
            return _context.GetUsers != null ?
                        View(await _context.GetUsers.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.GetUsers'  is null.");
        }

        // GET: Users1/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.GetUsers == null)
            {
                return NotFound();
            }

            var user = await _context.GetUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Email,Gender,Country,Password,ConfirmPassword,Age")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = Guid.NewGuid();
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users1/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.GetUsers == null)
            {
                return NotFound();
            }

            var user = await _context.GetUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FirstName,MiddleName,LastName,Email,Gender,Country,Password,ConfirmPassword,Age")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users1/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.GetUsers == null)
            {
                return NotFound();
            }

            var user = await _context.GetUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.GetUsers == null)
            {
                return Problem("Entity set 'AppDbContext.GetUsers'  is null.");
            }
            var user = await _context.GetUsers.FindAsync(id);
            if (user != null)
            {
                _context.GetUsers.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(Guid id)
        {
          return (_context.GetUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
