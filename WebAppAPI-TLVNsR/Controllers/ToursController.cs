using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppAPI_TLVNsR.DataContext;
using WebAppAPI_TLVNsR.Models;

namespace WebAppAPI_TLVNsR.Controllers
{
    public class ToursController : Controller
    {
        private readonly TLVNsRsDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; 

        public ToursController(TLVNsRsDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment; 
        }

        // GET: Tours
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tours.ToListAsync());
        }

        // GET: Tours/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // GET: Tours/Create
        public IActionResult Create()
        {
            return View();
        }


        private string UploadFile(IFormFile file)
        {
            string fileName = null; 
            if (file.FileName != null && file.Length > 0)
            {
                string rootPath = _webHostEnvironment.WebRootPath;
                fileName = Path.GetFileNameWithoutExtension(file.FileName)
                                 + Guid.NewGuid() + Path.GetExtension(file.FileName);
                var imagePhysicalPath = Path.Combine(rootPath + "/Images", fileName);

                var fileStream = new FileStream(imagePhysicalPath, FileMode.Create);
                    file.CopyTo(fileStream);
                            }
            return fileName;
        }

        // POST: Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tour tour, IFormFile ItineraryFileName, IFormFile ImageFileName)
        {
            // Phai dat ten VARIABLE IFormFile trung voi ten variable muon upload cua Entity. Neu khong se gay ra error: 
            // NullReferenceException . Toi da mac sai lam tai hai nay vi toi nghi ten variable IFormFile dat sao cung dc. :(((
            if (ModelState.IsValid)
            {
                string imageName = UploadFile(ImageFileName);
                string itineraryName = UploadFile(ItineraryFileName);

                tour.ItineraryFileName = imageName;
                tour.ItineraryFileName = itineraryName;

                tour.Id = Guid.NewGuid();
                _context.Add(tour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tour);
        }
        //    if (ModelState.IsValid)
        //    {

        //        //if (ImageFileName.FileName != null && ImageFileName.Length > 0)                
        //        //{
        //        //    string rootPath = _webHostEnvironment.WebRootPath;
        //        //    string fileName = Path.GetFileNameWithoutExtension(ImageFileName.FileName)
        //        //                     + Guid.NewGuid() + Path.GetExtension(ImageFileName.FileName); 
        //        //    var imagePhysicalPath = Path.Combine(rootPath + "/Images", fileName);

        //        //    var fileStream = new FileStream(imagePhysicalPath, FileMode.Create);
        //        //    await ImageFileName.CopyToAsync(fileStream);

        //        //    tour.ImageFileName = fileName; 

        //        //}

        //        //if (ItineraryFileName.FileName != null && ItineraryFileName.Length > 0)
        //        //{
        //        //    string rootPath = _webHostEnvironment.WebRootPath;
        //        //    string fileName = Path.GetFileNameWithoutExtension(ItineraryFileName.FileName)
        //        //        + Guid.NewGuid() + Path.GetExtension(ItineraryFileName.FileName);
        //        //    var itineraryPhysicalPath = Path.Combine(rootPath + "/Itineraries", fileName);
        //        //    var fileStream = new FileStream(itineraryPhysicalPath, FileMode.Create);
        //        //    await ItineraryFileName.CopyToAsync(fileStream);
        //        //    tour.ItineraryFileName = fileName; 

        //        //}

        //        string imageName =  UploadFile(ImageFileName);
        //        string itineraryName = UploadFile(ItineraryFileName);

        //        tour.ItineraryFileName = imageName;
        //        tour.ItineraryFileName = itineraryName; 

        //        tour.Id = Guid.NewGuid();
        //        _context.Add(tour);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tour);
        //}

        // GET: Tours/Edit/5

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound();
            }
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TitleTour,DescriptionTour,ItineraryFileName,PriceTour,LengthTour,MinParticipant,MaxParticipant,ImageFileName,DateCreated")] Tour tour)
        {
            if (id != tour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourExists(tour.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tour);
        }

        // GET: Tours/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tour = await _context.Tours.FindAsync(id);
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourExists(Guid id)
        {
            return _context.Tours.Any(e => e.Id == id);
        }
    }
}
