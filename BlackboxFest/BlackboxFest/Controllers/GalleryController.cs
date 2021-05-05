using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackboxFest.Data;
using BlackboxFest.Models;
using BlackboxFest.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace BlackboxFest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GalleryController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Gallery
        public async Task<IActionResult> Index()
        {
            GalleryViewModel viewModel = new GalleryViewModel();
            viewModel.Galleries = await _context.Galleries.ToListAsync();
            return View(viewModel);
        }
        [AllowAnonymous]
        public async Task<IActionResult> GalleryViewUser()
        {
            GalleryViewModel viewModel = new GalleryViewModel();
            viewModel.Galleries = await _context.Galleries.ToListAsync();
            return View(viewModel);
        }
        // GET: Gallery/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // GET: Gallery/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gallery/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GalleryViewModel viewModel)
        {
            if (viewModel.Gallery.ImageFile != null)
            {
                //Save image to wwwroot/image



                string wwwrootPath = _hostEnvironment.WebRootPath;
                string FileName = Path.GetFileNameWithoutExtension(viewModel.Gallery.ImageFile.FileName);
                string extension = Path.GetExtension(viewModel.Gallery.ImageFile.FileName);
                viewModel.Gallery.ImageName = FileName = FileName + extension;
                string path = Path.Combine(wwwrootPath + "/images/", FileName);
                viewModel.Gallery.ImageName = "/images/" + viewModel.Gallery.ImageName;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await viewModel.Gallery.ImageFile.CopyToAsync(fileStream);
                }


                //Insert record
                _context.Add(viewModel.Gallery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); ;
            }
            return View(viewModel);
        }

        // GET: Gallery/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }
            return View(gallery);
        }

        // POST: Gallery/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageName")] Gallery gallery)
        {
            if (id != gallery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gallery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GalleryExists(gallery.Id))
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
            return View(gallery);
        }

        // GET: Gallery/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gallery = await _context.Galleries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gallery == null)
            {
                return NotFound();
            }

            return View(gallery);
        }

        // POST: Gallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gallery = await _context.Galleries.FindAsync(id);
            _context.Galleries.Remove(gallery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GalleryExists(int id)
        {
            return _context.Galleries.Any(e => e.Id == id);
        }
    }
}
