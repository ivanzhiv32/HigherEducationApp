using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HigherEducationApp.Data;
using HigherEducationApp.Models;
using HigherEducationApp.Services;
using Microsoft.Extensions.Logging;
using HigherEducationApp.Dto;

namespace HigherEducationApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearReportController : Controller
    {
        private readonly HigherEducationSystemDbContext _context;
        private readonly ILogger<YearReportController> _logger;
        private YearReportService yearReportService = new YearReportService();

        public YearReportController(HigherEducationSystemDbContext context)
        {
            _context = context;
        }

        //public YearReportsController(ILogger<YearReportController> logger, IServiceProvider serviceProvider)
        //{
        //    _logger = logger;
        //    //yearReportService = serviceProvider.GetService(YearReportService);
        //}


        // GET: api/YearReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<YearReport>>> GetYearReports()
        {
            return await _context.YearReports.ToListAsync();
        }

        // GET: api/YearReports/2022
        [HttpGet("{year}")]
        public async Task<ActionResult<YearReportDto>> GetYearReport(int year)
        {
            var yearReport = yearReportService.GetYearReport(year);

            if (yearReport == null)
            {
                return NotFound();
            }

            return yearReport;
        }

        // PUT: api/YearReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYearReport(int id, YearReport yearReport)
        {
            if (id != yearReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(yearReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/YearReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<YearReport>> PostYearReport(YearReport yearReport)
        {
            _context.YearReports.Add(yearReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYearReport", new { id = yearReport.Id }, yearReport);
        }

        // DELETE: api/YearReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYearReport(int id)
        {
            var yearReport = await _context.YearReports.FindAsync(id);
            if (yearReport == null)
            {
                return NotFound();
            }

            _context.YearReports.Remove(yearReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool YearReportExists(int id)
        {
            return _context.YearReports.Any(e => e.Id == id);
        }
    }
}
