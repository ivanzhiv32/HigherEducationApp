using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HigherEducationApp.Data;
using HigherEducationApp.Models;

namespace HigherEducationApp.Controllers
{
    public class RatingInstitutionsController : Controller
    {
        private readonly HigherEducationSystemDbContext _context;

        public RatingInstitutionsController(HigherEducationSystemDbContext context)
        {
            _context = context;
        }

        // GET: RatingInstitutions
        public async Task<IActionResult> Index()
        {
            return View(await _context.RatingInstitution.ToListAsync());
        }

        // GET: RatingInstitutions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratingInstitution = await _context.RatingInstitution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ratingInstitution == null)
            {
                return NotFound();
            }

            return View(ratingInstitution);
        }

        // GET: RatingInstitutions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RatingInstitutions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rating")] RatingInstitution ratingInstitution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ratingInstitution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ratingInstitution);
        }

        // GET: RatingInstitutions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratingInstitution = await _context.RatingInstitution.FindAsync(id);
            if (ratingInstitution == null)
            {
                return NotFound();
            }
            return View(ratingInstitution);
        }

        // POST: RatingInstitutions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rating")] RatingInstitution ratingInstitution)
        {
            if (id != ratingInstitution.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ratingInstitution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingInstitutionExists(ratingInstitution.Id))
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
            return View(ratingInstitution);
        }

        // GET: RatingInstitutions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ratingInstitution = await _context.RatingInstitution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ratingInstitution == null)
            {
                return NotFound();
            }

            return View(ratingInstitution);
        }

        // POST: RatingInstitutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ratingInstitution = await _context.RatingInstitution.FindAsync(id);
            _context.RatingInstitution.Remove(ratingInstitution);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RatingInstitutionExists(int id)
        {
            return _context.RatingInstitution.Any(e => e.Id == id);
        }
    }
}
