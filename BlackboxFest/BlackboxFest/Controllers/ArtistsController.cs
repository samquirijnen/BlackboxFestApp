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
using BlackboxFest.Data.UnitOfWork;

namespace BlackboxFest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ArtistsController : Controller
    {
       // private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _uow;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ArtistsController(IUnitOfWork uow, IWebHostEnvironment hostEnvironment)
        {
            //  _context = context;
            _uow = uow;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Artists
        public async Task<IActionResult> Index()
        {
            ArtistViewModel viewModel = new ArtistViewModel();
            viewModel.Artists = await _uow.ArtistRepository.GetAll().ToListAsync();
            return View(viewModel);
        }
        [AllowAnonymous]
        public async Task<IActionResult> ArtistViewUser()
        {


            ConcertViewModel viewModel = new ConcertViewModel();
            viewModel.Concerts = await _uow.ConcertRepository.GetAll().Include(c => c.Artist).Include(c => c.Stage).ToListAsync();
            return View(viewModel);


        }
        [AllowAnonymous]
        public async Task<IActionResult> ArtistDay1()
        {
            ConcertViewModel viewModel = new ConcertViewModel();
            viewModel.Concerts = await _uow.ConcertRepository.GetAll().Include(c => c.Artist).Include(c => c.Stage).ToListAsync();
            return View(viewModel);


        }
        [AllowAnonymous]
        public async Task<IActionResult> ArtistDay2()
        {
            ConcertViewModel viewModel = new ConcertViewModel();
            viewModel.Concerts = await _uow.ConcertRepository.GetAll().Include(c => c.Artist).Include(c => c.Stage).ToListAsync();
            return View(viewModel);


        }
        [AllowAnonymous]
        public async Task<IActionResult> ArtistDay3()
        {
            ConcertViewModel viewModel = new ConcertViewModel();
            viewModel.Concerts = await _uow.ConcertRepository.GetAll().Include(c => c.Artist).Include(c => c.Stage).ToListAsync();
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

          
            var artist = await _uow.ArtistRepository.GetAll().FirstOrDefaultAsync(m=>m.Id == id);
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
             
                _uow.ArtistRepository.Create(artist);
            
                await _uow.Save();
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

        
            var artist = await _uow.ArtistRepository.GetById(id);
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

                    _uow.ArtistRepository.Update(artist);
                    await _uow.Save();
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

          
            var artist = await _uow.ArtistRepository.GetAll()
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
           
            var artist = await _uow.ArtistRepository.GetById(id);
            _uow.ArtistRepository.Delete(artist);
           
            await _uow.Save();
           return RedirectToAction(nameof(Index));
     
        }

        private bool ArtistExists(int id)
        {
         

            return _uow.ArtistRepository.GetAll().Any(e => e.Id == id);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Search(ConcertViewModel viewModel)
        {
            if (!string.IsNullOrWhiteSpace(viewModel.EventSearch))
            {
               
                viewModel.Concerts = await _uow.ConcertRepository.GetAll().Include(x=>x.Artist)

                   .Where(e => e.Artist.Name.Contains(viewModel.EventSearch))

                   .ToListAsync();
            }
            else
            {
                viewModel.Concerts = await _uow.ConcertRepository.GetAll().Include(x => x.Artist).ToListAsync();
            }
            return View("ArtistViewUser", viewModel);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Day1Button(ConcertViewModel viewModel)
        {



            viewModel.Concerts = await _uow.ConcertRepository.GetAll().Include(x=>x.Artist).Where(x => x.Date == DateTime.Parse("25/09/2021")).ToListAsync();


           
            return LocalRedirect("~/Artists/ArtistViewUser/" + viewModel);
        }



    }
}
