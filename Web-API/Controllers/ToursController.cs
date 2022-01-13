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
    public class ToursController : ControllerBase
    {
        private readonly TLVNRsDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ToursController(TLVNRsDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetTours()
        {
            return await _context.Tours.ToListAsync();
        }

        // GET: api/Tours/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTour(Guid id)
        {
            var tour = await _context.Tours.FindAsync(id);

            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }

        // PUT: api/Tours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour(Guid id, Tour tour)
        {
            if (id != tour.Id)
            {
                return BadRequest();
            }

            _context.Entry(tour).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
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

        // POST: api/Tours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tour>> PostTour(Tour tour)
        {

            //IFormFile image
            //string fileName = null;

            //if (ModelState.IsValid)
            //{
            //    if (image.FileName != null && image.Length > 0)
            //    {
            //        string rootPath = _webHostEnvironment.WebRootPath;
            //        fileName = Path.GetFileNameWithoutExtension(image.FileName)
            //                    + Guid.NewGuid() + Path.GetExtension(image.FileName);
            //        var pathUpload = Path.Combine(rootPath + "/Images", fileName);

            //        var fileStream = new FileStream(pathUpload, FileMode.Create);
            //        await image.CopyToAsync(fileStream);
            //        tour.ImageFileName = fileName; 
            //    }
            //}
            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTour", new { id = tour.Id }, tour);
        }

        // DELETE: api/Tours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour(Guid id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }

            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TourExists(Guid id)
        {
            return _context.Tours.Any(e => e.Id == id);
        }

        [Route("UploadFile")]
        [HttpPost]
        public JsonResult UploadFile()
        {
            //string fileName = null;
            //IFormFile image
            try
            {
                string rootPath = _webHostEnvironment.WebRootPath;
                var htppResquest = Request.Form;
                var postedFile = htppResquest.Files[0];
                string fileName = postedFile.FileName;
                //string fileName = Path.GetFileNameWithoutExtension(image.FileName)
                //            + Guid.NewGuid() + Path.GetExtension(image.FileName);
                var pathUpload = Path.Combine(rootPath + "/Images", fileName);

                var fileStream = new FileStream(pathUpload, FileMode.Create);
                //image.CopyTo(fileStream);
                return new JsonResult(fileName);
            }
            catch (Exception)
            {

                return new JsonResult("anonymus.png"); 
            }
                  
                
            
            
        }
    }
}
