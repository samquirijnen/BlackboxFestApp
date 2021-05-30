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

namespace BlackboxFest.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ConcertController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Concert
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcerts()
        {
            return await _uow.ConcertRepository.GetAll().ToListAsync();
        }

        // GET: api/Concert/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concert>> GetConcert(int id)
        {
            var concert = await _uow.ConcertRepository.GetById(id);

            if (concert == null)
            {
                return NotFound();
            }

            return concert;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpGet("ConcertList")]
        public async Task<ActionResult<IEnumerable<Concert>>> GetConcertList()
        {


            return await _uow.ConcertRepository.GetAll().Include(c => c.Artist).Include(c => c.Stage).Include(x=>x.DateDayFestival).ToListAsync();
        }

        // PUT: api/Concert/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcert(int id, Concert concert)
        {
            if (id != concert.Id)
            {
                return BadRequest();
            }
            _uow.ConcertRepository.Update(concert);
           // _context.Entry(concert).State = EntityState.Modified;

            try
            {
                await _uow.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcertExists(id))
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

        // POST: api/Concert
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Concert>> PostConcert(Concert concert)
        {
            _uow.ConcertRepository.Create(concert);
            await _uow.Save(); ;

            return CreatedAtAction("GetConcert", new { id = concert.Id }, concert);
        }

        // DELETE: api/Concert/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Concert>> DeleteConcert(int id)
        {
            var concert = await _uow.ConcertRepository.GetById(id);
            if (concert == null)
            {
                return NotFound();
            }

            _uow.ConcertRepository.Delete(concert);
            await _uow.Save();

           // return concert;
            return NoContent();
        }

        private bool ConcertExists(int id)
        {
            return _uow.ConcertRepository.GetAll().Any(e => e.Id == id);
        }
    }
}
