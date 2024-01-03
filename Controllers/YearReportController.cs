using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HigherEducationApp.Data;
using HigherEducationApp.Models;
using HigherEducationApp.Dto;
using HigherEducationApp.Services;

namespace HigherEducationApp.Controllers
{
    public class YearReportController : Controller
    {
        private readonly HigherEducationSystemDbContext _context;
        private YearReportService yearReportService = new YearReportService();

        public YearReportController(HigherEducationSystemDbContext context)
        {
            _context = context;
        }

        // GET: YearReport
        public async Task<IActionResult> Index()
        {
            YearReportDto yearReport = yearReportService.GetYearReport(2023);

            return View(yearReport);
        }

        // GET: YearReport/Details/5
        public async Task<IActionResult> Details(int year)
        {
            if (year == null)
            {
                return NotFound();
            }

            YearReportDto yearReport = yearReportService.GetYearReport(year);
            if (yearReport == null)
            {
                return NotFound();
            }

            return View(yearReport);
        }

        // GET: YearReport/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YearReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,CountAllStudents,CountFullTimeStudents,CountFreeFormStudents")] YearReport yearReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yearReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yearReport);
        }

        // GET: YearReport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yearReport = await _context.YearReports.FindAsync(id);
            if (yearReport == null)
            {
                return NotFound();
            }
            return View(yearReport);
        }

        // POST: YearReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Year,CountAllStudents,CountFullTimeStudents,CountFreeFormStudents")] YearReport yearReport)
        {
            if (id != yearReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yearReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YearReportExists(yearReport.Id))
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
            return View(yearReport);
        }

        // GET: YearReport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yearReport = await _context.YearReports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yearReport == null)
            {
                return NotFound();
            }

            return View(yearReport);
        }

        // POST: YearReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yearReport = await _context.YearReports.FindAsync(id);
            _context.YearReports.Remove(yearReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YearReportExists(int id)
        {
            return _context.YearReports.Any(e => e.Id == id);
        }
    }
}
