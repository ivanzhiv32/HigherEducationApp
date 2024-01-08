using System;
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
    public class RatingInstitutionsController : Controller
    {
        private readonly HigherEducationSystemDbContext _context;
        private RatingService ratingService = new RatingService();

        public RatingInstitutionsController(HigherEducationSystemDbContext context)
        {
            _context = context;
        }

        // GET: RatingInstitutions
        public async Task<IActionResult> Index()
        {
            ratingService.GetRatingInstitutions();
            return View(await _context.RatingInstitution.ToListAsync());
        }
    }
}
