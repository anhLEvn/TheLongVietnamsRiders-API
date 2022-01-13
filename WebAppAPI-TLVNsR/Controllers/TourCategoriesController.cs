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
    public class TourCategoriesController : Controller
    {
        private readonly TLVNsRsDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TourCategoriesController(TLVNsRsDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment; 
        }

        // GET: TourCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.TourCategories.ToListAsync());
        }

        // GET: TourCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourCategory = await _context.TourCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tourCategory == null)
            {
                return NotFound();
            }

            return View(tourCategory);
        }

        // GET: TourCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TourCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,NameCategory,DescriptionCate,AvatarImageFileName")] TourCategory tourCategory, IFormFile avatarImage)
        public async Task<IActionResult> Create(TourCategory tourCategory, IFormFile AvatarImageFileName)
        {
            if (ModelState.IsValid)
            {
                if (AvatarImageFileName == null)
                {
                    Environment.FailFast("image is null"); 
                }

                    else if (AvatarImageFileName.FileName != null && AvatarImageFileName.Length > 0)
                        {
                    string rootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(AvatarImageFileName.FileName)
                                     + Guid.NewGuid() + Path.GetExtension(AvatarImageFileName.FileName);
                    var imagePhysicalPath = Path.Combine(rootPath + "/Images/", fileName);

                    var fileStream = new FileStream(imagePhysicalPath, FileMode.Create);
                    await AvatarImageFileName.CopyToAsync(fileStream);
                    fileStream.Close(); // free the resource

                    tourCategory.AvatarImageFileName = fileName;

                }
                
                _context.Add(tourCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tourCategory);
        }

        // GET: TourCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourCategory = await _context.TourCategories.FindAsync(id);
            if (tourCategory == null)
            {
                return NotFound();
            }
            return View(tourCategory);
        }

        // POST: TourCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameCategory,DescriptionCate,AvatarImageFileName")] TourCategory tourCategory)
        {
            if (id != tourCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tourCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourCategoryExists(tourCategory.Id))
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
            return View(tourCategory);
        }

        // GET: TourCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tourCategory = await _context.TourCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tourCategory == null)
            {
                return NotFound();
            }

            return View(tourCategory);
        }

        // POST: TourCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tourCategory = await _context.TourCategories.FindAsync(id);
            _context.TourCategories.Remove(tourCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourCategoryExists(int id)
        {
            return _context.TourCategories.Any(e => e.Id == id);
        }
    }
}
