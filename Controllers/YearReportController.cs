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
        //public async Task<IActionResult> Index()
        //{
        //    YearReportDto yearReport = yearReportService.GetYearReport(2023);

        //    return View(yearReport);
        //}
        public async Task<IActionResult> Index(int year)
        {
            if (year < 2015 || year > 2023)
            {
                return NotFound();
            }

            YearReport yearReport = yearReportService.GetYearReport(year);
            if (yearReport == null)
            {
                return NotFound();
            }

            return View(yearReport);
        }

        // GET: YearReport/Details/5
        public async Task<IActionResult> Details(int year)
        {
            if (year == null)
            {
                return NotFound();
            }

            YearReport yearReport = yearReportService.GetYearReport(year);
            if (yearReport == null)
            {
                return NotFound();
            }

            return View(yearReport);
        }
    }
}
