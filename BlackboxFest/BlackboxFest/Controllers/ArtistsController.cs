using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackboxFest.Data;
using BlackboxFest.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using BlackboxFest.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BlackboxFest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArtistsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ArtistsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Artists
        public async Task<IActionResult> Index()
        {
            ArtistViewModel viewModel = new ArtistViewModel();
            viewModel.Artists = await _context.Artists.ToListAsync();
            return View(viewModel);
        }
        [AllowAnonymous]
        public async Task<IActionResult> ArtistViewUser()
        {
            ArtistViewModel viewModel = new ArtistViewModel();
            viewModel.Artists = await _context.Artists.ToListAsync();
            return View(viewModel);
        }
        [AllowAnonymous]
        // GET: Artists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ArtistShortDescription,ArtistLongDescription,MusicGenre,ImageFile")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
              


                    string wwwrootPath = _hostEnvironment.WebRootPath;
                    string FileName =  Path.GetFileNameWithoutExtension(artist.ImageFile.FileName);
                    string extension = Path.GetExtension(artist.ImageFile.FileName);
                    artist.ImageName = FileName = FileName + extension;
                    string path = Path.Combine(wwwrootPath + "/images/" , FileName);
                    artist.ImageName = "/images/" + artist.ImageName;
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await artist.ImageFile.CopyToAsync(fileStream);
                    }

            
                //Insert record
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ArtistShortDescription,ArtistLongDescription,MusicGenre,ImageName,NewImageName,ImageFile")] Artist artist)
        {
            artist.NewImageName = artist.ImageName;
            if (id != artist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (artist.ImageName != null)
                {
                    var imagepath = Path.Combine(_hostEnvironment.WebRootPath, "image", artist.ImageName);
                    if (System.IO.File.Exists(imagepath))
                    {
                        System.IO.File.Delete(imagepath);
                    }
                }
                if (artist.ImageFile != null)
                {

                    string wwwrootPath = _hostEnvironment.WebRootPath;
                    string FileName = Path.GetFileNameWithoutExtension(artist.ImageFile.FileName);
                    string extension = Path.GetExtension(artist.ImageFile.FileName);
                    artist.NewImageName = FileName = FileName  + extension;
                    string path = Path.Combine(wwwrootPath + "/images/" , FileName);
                    string NewImageName = "/images/" + artist.NewImageName;
                    artist.NewImageName = NewImageName;
                    using (var fileStream = new FileStream(path, FileMode.Create))

                    {
                        await artist.ImageFile.CopyToAsync(fileStream);
                    }
                                                                    
                }
                artist.ImageName = artist.NewImageName;
                try
                {
                    
                    _context.Update(artist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(artist.Id))
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
            return View(artist);
        }

        // GET: Artists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
           return RedirectToAction(nameof(Index));
     
        }

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Search(ArtistViewModel viewModel)
        {
            if (!string.IsNullOrWhiteSpace(viewModel.EventSearch))
            {
                viewModel.Artists = await _context.Artists
                   
                    .Where(e => e.Name.Contains(viewModel.EventSearch))
                   
                    .ToListAsync();
            }
            else
            {
                viewModel.Artists = await _context.Artists.ToListAsync();
            }
            return View("ArtistViewUser", viewModel);
        }

    }
}
