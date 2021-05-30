using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlackboxFest.Data;
using BlackboxFest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BlackboxFest.Data.UnitOfWork;
using BlackboxFest.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BlackboxFest.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
       
        private readonly IUnitOfWork _uow;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ArtistsController(IUnitOfWork uow, IWebHostEnvironment hostEnvironment)
        {
            _uow = uow;
            _hostEnvironment = hostEnvironment;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await _uow.ArtistRepository.GetAll().ToListAsync();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _uow.ArtistRepository.GetById(id);

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("ArtistList")]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtistList()
        {


            return await _uow.ArtistRepository.GetAll().ToListAsync();
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id != artist.Id)
            {
                return BadRequest();
            }
            _uow.ArtistRepository.Update(artist);
            // _uow.Entry(artist).State = EntityState.Modified;

            try
            {
                await _uow.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            //artist.NewImageName = artist.ImageName;
            //if (id != artist.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    if (artist.ImageName != null)
            //    {
            //        var imagepath = Path.Combine(_hostEnvironment.WebRootPath, "image", artist.ImageName);
            //        if (System.IO.File.Exists(imagepath))
            //        {
            //            System.IO.File.Delete(imagepath);
            //        }
            //    }
            //if (artist.ImageFile != null)
            //{

            //    string wwwrootPath = _hostEnvironment.WebRootPath;
            //    string FileName = Path.GetFileNameWithoutExtension(artist.ImageFile.FileName);
            //    string extension = Path.GetExtension(artist.ImageFile.FileName);
            //    artist.NewImageName = FileName = FileName + extension;
            //    string path = Path.Combine(wwwrootPath + "/images/", FileName);
            //    string NewImageName = "/images/" + artist.NewImageName;
            //    artist.NewImageName = NewImageName;
            //    using (var fileStream = new FileStream(path, FileMode.Create))

            //    {
            //        await artist.ImageFile.CopyToAsync(fileStream);
            //    }

            //}
            //    artist.ImageName = artist.NewImageName;
            //    try
            //    {

            //        _uow.ArtistRepository.Update(artist);
            //        await _uow.Save();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ArtistExists(artist.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return NoContent();
            //}
            //return NoContent();
        }

        // POST: api/Artists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            _uow.ArtistRepository.Create(artist);
            //_context.Artists.Add(artist);
            await _uow.Save();

            return CreatedAtAction("GetArtist", new { id = artist.Id }, artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artist>> DeleteArtist(int id, ArtistViewModel viewModel)
        {
            //var artist = await _uow.ArtistRepository.GetById(id);

            //if (artist == null)
            //{
               
            //        return NotFound();
              
               
            //}
            //_uow.ArtistRepository.Delete(artist);

            //await _uow.Save();

            ////  return artist;
            //return NoContent();
            viewModel.Artist = await _uow.ArtistRepository.GetById(id);
            viewModel.Concerts = await _uow.ConcertRepository.GetAll().Where(x => x.ArtistID == id).ToListAsync();

            if (viewModel.Artist != null)
            {
                if (id != viewModel.Artist.Id)
                {
                    return NotFound();
                }
                else
                {
                    _uow.ArtistRepository.Delete(viewModel.Artist);

                }
                await _uow.Save();
            }
            return NoContent();
        }

        private bool ArtistExists(int id)
        {
            return  _uow.ArtistRepository.GetAll().Any(e => e.Id == id);
        }
    }
}
