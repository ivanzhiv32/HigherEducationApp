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
        public async Task<IActionResult> Index(int id, int year)
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
    }
}
