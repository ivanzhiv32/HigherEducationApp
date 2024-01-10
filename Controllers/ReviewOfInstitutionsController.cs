using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HigherEducationApp.Data;
using HigherEducationApp.Models;
using HigherEducationApp.Services;

namespace HigherEducationApp.Controllers
{
    public class ReviewOfInstitutionsController : Controller
    {
        private readonly HigherEducationSystemDbContext _context;
        private ReviewService reviewService = new ReviewService();

        public ReviewOfInstitutionsController(HigherEducationSystemDbContext context)
        {
            _context = context;
        }

        // GET: ReviewOfInstitutions
        public async Task<IActionResult> Index()
        {
            var reviews = reviewService.AddReview();


            return View(await _context.ReviewsOfInstitution.ToListAsync());
        }

        // GET: ReviewOfInstitutions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewOfInstitution = await _context.ReviewsOfInstitution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviewOfInstitution == null)
            {
                return NotFound();
            }

            return View(reviewOfInstitution);
        }

        // GET: ReviewOfInstitutions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReviewOfInstitutions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tonality,Text,AuthorStatus")] ReviewOfInstitution reviewOfInstitution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviewOfInstitution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reviewOfInstitution);
        }

        // GET: ReviewOfInstitutions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewOfInstitution = await _context.ReviewsOfInstitution.FindAsync(id);
            if (reviewOfInstitution == null)
            {
                return NotFound();
            }
            return View(reviewOfInstitution);
        }

        // POST: ReviewOfInstitutions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tonality,Text,AuthorStatus")] ReviewOfInstitution reviewOfInstitution)
        {
            if (id != reviewOfInstitution.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviewOfInstitution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewOfInstitutionExists(reviewOfInstitution.Id))
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
            return View(reviewOfInstitution);
        }

        // GET: ReviewOfInstitutions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviewOfInstitution = await _context.ReviewsOfInstitution
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviewOfInstitution == null)
            {
                return NotFound();
            }

            return View(reviewOfInstitution);
        }

        // POST: ReviewOfInstitutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviewOfInstitution = await _context.ReviewsOfInstitution.FindAsync(id);
            _context.ReviewsOfInstitution.Remove(reviewOfInstitution);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewOfInstitutionExists(int id)
        {
            return _context.ReviewsOfInstitution.Any(e => e.Id == id);
        }
    }
}
