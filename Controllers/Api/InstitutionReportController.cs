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

namespace HigherEducationApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitutionReportController : ControllerBase
    {
        private readonly HigherEducationSystemDbContext _context;

        private InstitutionReportService institutionReportService = new InstitutionReportService();

        public InstitutionReportController(HigherEducationSystemDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Возвращает показатели отчета по названию
        /// </summary>
        /// <returns></returns>
        [HttpGet("getIndicatorInstitution")]
        public async Task<ActionResult<List<Indicator>>> GetInstitutionReport(int id, int year, string number)
        {
            List<Indicator> indicators = new List<Indicator>();
            for (int i = year; i > 2015; i--)
            {
                if (i == year - 4) break;
                indicators.Add(institutionReportService.GetIndicatorByNumber(id, i, number));
            }

            if (indicators == null)
            {
                return NotFound();
            }

            return indicators;
        }

        // GET: api/InstitutionReport/5/2022
        //[HttpGet("{id}, {year}")]
        //public async Task<ActionResult<List<InstitutionReport>>> GetInstitutionReports(int id, int year)
        //{
        //    List<InstitutionReport> institutionReports = new List<InstitutionReport>();
        //    for (int i = year; i > 2015; i--)
        //    {
        //        if (i == year - 4) break;
        //        institutionReports.Add(institutionReportService.GetReportWithIndicators(id, i));
        //    }

        //    if (institutionReports == null)
        //    {
        //        return NotFound();
        //    }

        //    return institutionReports;
        //}

        // GET: api/InstitutionReport/5
        [HttpGet("getInstitutionReport")]
        //[Route("api/InstitutionReport/{id}")]
        public async Task<ActionResult<InstitutionReport>> GetInstitutionReport(int id)
        {
            var institutionReport = await _context.InstitutionReports.FindAsync(id);

            if (institutionReport == null)
            {
                return NotFound();
            }

            return institutionReport;
        }

        /// <summary>
        /// Возвращает показатели отчета по названию
        /// </summary>
        /// <returns></returns>
        [HttpPut("updateInstitutionReport")]
        public async Task<IActionResult> PutInstitutionReport(int id, InstitutionReport institutionReport)
        {
            if (id != institutionReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(institutionReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitutionReportExists(id))
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

        // POST: api/InstitutionReport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("addInstitutionReport")]
        public async Task<ActionResult<InstitutionReport>> PostInstitutionReport(InstitutionReport institutionReport)
        {
            _context.InstitutionReports.Add(institutionReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstitutionReport", new { id = institutionReport.Id }, institutionReport);
        }

        // DELETE: api/InstitutionReport/5
        [HttpDelete("deleteInstitutionReport")]
        public async Task<IActionResult> DeleteInstitutionReport(int id)
        {
            var institutionReport = await _context.InstitutionReports.FindAsync(id);
            if (institutionReport == null)
            {
                return NotFound();
            }

            _context.InstitutionReports.Remove(institutionReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstitutionReportExists(int id)
        {
            return _context.InstitutionReports.Any(e => e.Id == id);
        }
    }
}
