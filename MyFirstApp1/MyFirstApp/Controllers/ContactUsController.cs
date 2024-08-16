using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsAcademy.Data;
using SportsAcademy.Models;

namespace SportsAcademy.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly AppDbContext _context;

        public ContactUsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ContactUs
        public async Task<IActionResult> Index()
        {
              return _context.ContactUss != null ? 
                          View(await _context.ContactUss.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.ContactUss'  is null.");
        }

        // GET: ContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactUss == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUss
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // GET: ContactUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Description")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactUs);
        }

        // GET: ContactUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactUss == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUss.FindAsync(id);
            if (contactUs == null)
            {
                return NotFound();
            }
            return View(contactUs);
        }

        // POST: ContactUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Description")] ContactUs contactUs)
        {
            if (id != contactUs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactUsExists(contactUs.Id))
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
            return View(contactUs);
        }

        // GET: ContactUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContactUss == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUss
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }



        // POST: ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactUss == null)
            {
                return Problem("Entity set 'AppDbContext.ContactUss'  is null.");
            }
            var contactUs = await _context.ContactUss.FindAsync(id);
            if (contactUs != null)
            {
                _context.ContactUss.Remove(contactUs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactUsExists(int id)
        {
          return (_context.ContactUss?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
    

  
}
