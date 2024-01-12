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
        private Dictionary<int, int[]> indicatorsDop = new Dictionary<int, int[]>()
        {
            {2023, new int[7]{ 1206, 510, 10, 29, 21, 898, 308 } },
            {2022, new int[7]{ 1208, 510, 10, 29, 21, 896, 312 } },
            {2021, new int[7]{ 1222, 530, 10, 29, 21, 906, 316 } },
            {2020, new int[7]{ 1218, 529, 10, 29, 21, 908, 310 } },
            {2019, new int[7]{ 1264, 555, 10, 29, 21, 920, 344 } },
            {2018, new int[7]{ 1314, 583, 10, 29, 21, 939, 375 } },
            {2017, new int[7]{ 769, 692, 0, 0, 0, 0, 0 } },
            {2016, new int[7]{ 830, 932, 0, 0, 0, 0, 0 } },
            {2015, new int[7]{ 901, 1232, 0, 0, 0, 0, 0 } }
        };


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
            ViewBag.Indicators = indicatorsDop[year];
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
