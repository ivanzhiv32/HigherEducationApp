using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HigherEducationApp.Data;
using HigherEducationApp.Models;

namespace HigherEducationApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionReportController : ControllerBase
    {
        private readonly HigherEducationSystemDbContext _context;

        public RegionReportController(HigherEducationSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/RegionReport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionReport>>> GetRegionReports()
        {
            return await _context.RegionReports.ToListAsync();
        }

        // GET: api/RegionReport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegionReport>> GetRegionReport(int id)
        {
            var regionReport = await _context.RegionReports.FindAsync(id);

            if (regionReport == null)
            {
                return NotFound();
            }

            return regionReport;
        }

        // PUT: api/RegionReport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegionReport(int id, RegionReport regionReport)
        {
            if (id != regionReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(regionReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionReportExists(id))
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

        // POST: api/RegionReport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegionReport>> PostRegionReport(RegionReport regionReport)
        {
            _context.RegionReports.Add(regionReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegionReport", new { id = regionReport.Id }, regionReport);
        }

        // DELETE: api/RegionReport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegionReport(int id)
        {
            var regionReport = await _context.RegionReports.FindAsync(id);
            if (regionReport == null)
            {
                return NotFound();
            }

            _context.RegionReports.Remove(regionReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegionReportExists(int id)
        {
            return _context.RegionReports.Any(e => e.Id == id);
        }
    }
}
