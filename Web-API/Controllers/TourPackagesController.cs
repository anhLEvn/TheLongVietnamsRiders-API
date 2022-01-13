using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourPackagesController : ControllerBase
    {
        private readonly TLVNRsDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; 

        public TourPackagesController(TLVNRsDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment; 
          
        }

        // GET: api/TourPackages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourPackage>>> GetTourPackages()
        {
            return await _context.TourPackages.ToListAsync();
        }

        // GET: api/TourPackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TourPackage>> GetTourPackage(Guid id)
        {
            var tourPackage = await _context.TourPackages.FindAsync(id);

            if (tourPackage == null)
            {
                return NotFound();
            }

            return tourPackage;
        }

        // PUT: api/TourPackages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTourPackage(Guid id, TourPackage tourPackage)
        {
            if (id != tourPackage.Id)
            {
                return BadRequest();
            }

            _context.Entry(tourPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourPackageExists(id))
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

        // POST: api/TourPackages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TourPackage>> PostTourPackage(TourPackage tourPackage, List<IFormFile> files)
        {
            
            _context.TourPackages.Add(tourPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTourPackage", new { id = tourPackage.Id }, tourPackage);
        }

        // DELETE: api/TourPackages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTourPackage(Guid id)
        {
            var tourPackage = await _context.TourPackages.FindAsync(id);
            if (tourPackage == null)
            {
                return NotFound();
            }

            _context.TourPackages.Remove(tourPackage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TourPackageExists(Guid id)
        {
            return _context.TourPackages.Any(e => e.Id == id);
        }
    }
}
