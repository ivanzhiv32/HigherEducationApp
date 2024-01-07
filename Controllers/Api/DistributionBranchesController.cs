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
    public class DistributionBranchesController : ControllerBase
    {
        private readonly HigherEducationSystemDbContext _context;
        private BranchScienceServise brancheScienceServise = new BranchScienceServise();

        public DistributionBranchesController(HigherEducationSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/DistributionBranches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistributionBranches>>> GetDistributionBranches()
        {
            return await _context.DistributionBranches.ToListAsync();
        }

        // GET: api/DistributionBranches/5
        [HttpGet("{idInstitution}, {year}")]
        public async Task<ActionResult<InstitutionReport>> GetDistributionBranches(int idInstitution, int year)
        {
            InstitutionReport institutionReports = new InstitutionReport();

            if (institutionReports == null)
            {
                return NotFound();
            }

            institutionReports = brancheScienceServise.GetReportWithBranchesScience(idInstitution, year);
            
            return institutionReports;
        }

        // PUT: api/DistributionBranches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistributionBranches(int id, DistributionBranches distributionBranches)
        {
            if (id != distributionBranches.Id)
            {
                return BadRequest();
            }

            _context.Entry(distributionBranches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistributionBranchesExists(id))
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

        // POST: api/DistributionBranches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DistributionBranches>> PostDistributionBranches(DistributionBranches distributionBranches)
        {
            _context.DistributionBranches.Add(distributionBranches);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistributionBranches", new { id = distributionBranches.Id }, distributionBranches);
        }

        // DELETE: api/DistributionBranches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistributionBranches(int id)
        {
            var distributionBranches = await _context.DistributionBranches.FindAsync(id);
            if (distributionBranches == null)
            {
                return NotFound();
            }

            _context.DistributionBranches.Remove(distributionBranches);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DistributionBranchesExists(int id)
        {
            return _context.DistributionBranches.Any(e => e.Id == id);
        }
    }
}
