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
using BlackboxFest.ViewModels;

namespace BlackboxFest.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public NewsController(ApplicationDbContext context , IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }
        public async Task<IActionResult> NewsViewUser()
        {
            NewsViewModel viewModel = new NewsViewModel();
            viewModel.NewsItems = await _context.News.ToListAsync();
            return View(viewModel);
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            NewsViewModel viewModel = new NewsViewModel();
            if (id == null)
            {
                return NotFound();
            }

            viewModel.News = await _context.News.FirstOrDefaultAsync(m => m.Id == id);
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsViewModel viewModel)
        {
            if (viewModel.News.ImageFile != null)
            {
                //Save image to wwwroot/image



                string wwwrootPath = _hostEnvironment.WebRootPath;
                string FileName = Path.GetFileNameWithoutExtension(viewModel.News.ImageFile.FileName);
                string extension = Path.GetExtension(viewModel.News.ImageFile.FileName);
                viewModel.News.ImageName = FileName = FileName + extension;
                string path = Path.Combine(wwwrootPath + "/images/", FileName);
                viewModel.News.ImageName = "/images/" + viewModel.News.ImageName;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await viewModel.News.ImageFile.CopyToAsync(fileStream);
                }


                //Insert record
                _context.Add(viewModel.News);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); ;
            }
            return View(viewModel);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ShortDescription,LongDescription,ImageUrl,Date,ImageName")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
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
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}
