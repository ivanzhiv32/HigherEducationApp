﻿using System;
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
    public class InstitutionReportController : Controller
    {
        private readonly HigherEducationSystemDbContext _context;
        private InstitutionReportService institutionReportService = new InstitutionReportService();
        private Dictionary<int, double> averageEGERus = new Dictionary<int, double>()
        {
            {2023,  63.87},
            {2022,  63.62},
            {2021,  63.31},
            {2020,  62.3},
            {2019,  59.85}
        };

        public InstitutionReportController(HigherEducationSystemDbContext context)
        {
            _context = context;
        }

        // GET: InstitutionReport
        public async Task<IActionResult> Index(int id, int year)
        {
            if (id == null)
            {
                return NotFound();
            }

            var minEGERus = institutionReportService.GetMinScoreRus(id);
            var averageEGE = institutionReportService.GetAverageScore(id);
            var minEGE = institutionReportService.GetMinScore(id);

            var institutionReport = institutionReportService.GetInstitutionReport(id, year);

            //var institutionReports = institutionReportService.GetInstitutionReports(id, year);
            //var countAverageCountForeignersRus = institutionReportService.GetAverageCountForeignersRus(id);
            //var countArticlesForeigners = institutionReportService.GetСountArticlesForeignersRus(id);
            //var volumeNIOKRRus = institutionReportService.GetVolumeNIOKRRus(id);
            //var countArticles = institutionReportService.GetAverageIndicatorRus(id, 99);
            //var countArticlesRegion = institutionReportService.GetAverageIndicatorRegion(id, 99, 4);

            //var rus = institutionReportService.GetAverageIndicatorRus(id, 62);
            //var region = institutionReportService.GetAverageIndicatorRegion(id, 62, 4);

            ViewBag.AverageEGERus = averageEGERus;
            ViewBag.AverageEGE = averageEGE;
            ViewBag.MinEGE = minEGE;
            ViewBag.MinEGERus = minEGERus;
            ViewBag.Institution = institutionReportService.GetInstitution(id);
            ViewBag.Branches = institutionReportService.GetBranchesScience(institutionReport.Id);
            ViewBag.Ugns = institutionReportService.GetUgns(id);
            ViewBag.FinanceIncome = institutionReportService.GetDistributionFinanceIncome(institutionReport.Id);

            List<InstitutionReport> institutionReports = new List<InstitutionReport>();
            for (int i = year; i > 2015; i--)
            {
                if (i == year - 4) break;
                institutionReports.Add(institutionReportService.GetReportWithIndicators(id, i));
            }
            ViewBag.Indicators = institutionReports;


            if (institutionReport == null)
            {
                return NotFound();
            }
            ViewData["year"] = year;
            return View(institutionReport);
        }

        // GET: InstitutionReport/Details/5
        public async Task<IActionResult> Details(int id, int year)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutionReport = institutionReportService.GetInstitutionReport(id, year);
            //var institutionReports = institutionReportService.GetInstitutionReports(id, year);
            ViewBag.Branches = institutionReportService.GetBranchesScience(institutionReport.Id);
            ViewBag.Ugns = institutionReportService.GetUgns(id);

            List<InstitutionReport> institutionReports = new List<InstitutionReport>();
            for (int i = year; i > 2015; i--)
            {
                if (i == year - 4) break;
                institutionReports.Add(institutionReportService.GetReportWithIndicators(id, i));
            }
            ViewBag.Indicators = institutionReports;
             

            if (institutionReport == null)
            {
                return NotFound();
            }
            ViewData["year"] = year;
            return View(institutionReport);
        }

        // GET: InstitutionReport/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstitutionReport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] InstitutionReport institutionReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(institutionReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(institutionReport);
        }

        // GET: InstitutionReport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutionReport = await _context.InstitutionReports.FindAsync(id);
            if (institutionReport == null)
            {
                return NotFound();
            }
            return View(institutionReport);
        }

        // POST: InstitutionReport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] InstitutionReport institutionReport)
        {
            if (id != institutionReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(institutionReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstitutionReportExists(institutionReport.Id))
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
            return View(institutionReport);
        }

        // GET: InstitutionReport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var institutionReport = await _context.InstitutionReports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (institutionReport == null)
            {
                return NotFound();
            }

            return View(institutionReport);
        }

        // POST: InstitutionReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var institutionReport = await _context.InstitutionReports.FindAsync(id);
            _context.InstitutionReports.Remove(institutionReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstitutionReportExists(int id)
        {
            return _context.InstitutionReports.Any(e => e.Id == id);
        }
    }
}
