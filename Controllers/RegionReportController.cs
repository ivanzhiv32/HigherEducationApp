using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HigherEducationApp.Data;
using HigherEducationApp.Models;
using HigherEducationApp.Dto.Region;
using HigherEducationApp.Services;

namespace HigherEducationApp.Controllers
{
    public class RegionReportController : Controller
    {
        private readonly HigherEducationSystemDbContext _context;
        private RegionService regionService = new RegionService();

        public RegionReportController(HigherEducationSystemDbContext context)
        {
            _context = context;
        }

        // GET: RegionReport
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegionReports.ToListAsync());
        }

        // GET: RegionReport/Details/5
        public async Task<IActionResult> Details(int id, int year)
        {
            if (id == null)
            {
                return NotFound();
            }

            RegionReport regionReport = regionService.GetRegionReport(id, year);
            if (regionReport == null)
            {
                return NotFound();
            }

            return View(regionReport);
        }

        // GET: RegionReport/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegionReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CountAllStudents,CountFullTimeStudents,CountFreeFormStudents")] RegionReport regionReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regionReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regionReport);
        }

        // GET: RegionReport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionReport = await _context.RegionReports.FindAsync(id);
            if (regionReport == null)
            {
                return NotFound();
            }
            return View(regionReport);
        }

        // POST: RegionReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CountAllStudents,CountFullTimeStudents,CountFreeFormStudents")] RegionReport regionReport)
        {
            if (id != regionReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regionReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionReportExists(regionReport.Id))
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
            return View(regionReport);
        }

        // GET: RegionReport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regionReport = await _context.RegionReports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regionReport == null)
            {
                return NotFound();
            }

            return View(regionReport);
        }

        // POST: RegionReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regionReport = await _context.RegionReports.FindAsync(id);
            _context.RegionReports.Remove(regionReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegionReportExists(int id)
        {
            return _context.RegionReports.Any(e => e.Id == id);
        }
    }
}
