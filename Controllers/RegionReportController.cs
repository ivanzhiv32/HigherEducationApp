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

        private Dictionary<int, int[]> indicatorsScience = new Dictionary<int, int[]>()
        {
            {2023, new int[8]{ 793967, 262305, 147284, 89226, 172926, 901026, 335333, 111652 } },
            {2022, new int[8]{ 763701, 250442, 142673, 83538, 166239, 867631, 322084, 108727 } },
            {2021, new int[8]{ 756181, 244426, 140208, 79695, 162635, 854309, 310278, 107249 } },
            {2020, new int[8]{ 762718, 238302, 134851, 76984, 158841, 838102, 295649, 104726 } },
            {2019, new int[8]{ 786077, 232801, 129957, 77791, 155326, 829849, 282859, 103628 } },
            {2018, new int[8]{ 834076, 231467, 125371, 77945, 151608, 821065, 271267, 102157 } },
            {2017, new int[8]{ 834076, 231467, 125371, 77945, 151608, 821065, 271267, 102157 } },
            {2016, new int[8]{ 834076, 231467, 125371, 77945, 151608, 821065, 271267, 102157 } },
            {2015, new int[8]{ 834076, 231467, 125371, 77945, 151608, 821065, 271267, 102157 } }
        };

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
            ViewBag.BranchScience = regionService.GetBranchesOfScince(id, year);
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
