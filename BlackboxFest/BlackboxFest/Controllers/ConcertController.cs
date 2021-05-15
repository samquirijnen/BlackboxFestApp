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
using BlackboxFest.Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BlackboxFest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ConcertController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly INotyfService _notyf;

        public ConcertController(IUnitOfWork uow, INotyfService notyf)
        {
            _uow = uow;
            _notyf = notyf;
        }

        // GET: Concert
        public async Task<IActionResult> Index()
        {
            //  ConcertViewModel viewModel = new ConcertViewModel();
            //viewModel.Concerts = await _uow.ConcertRepository.GetAll().Include(c => c.Artist).Include(c => c.Stage).ToListAsync();
            await  TimeTable("24/09/2021");
            return View();
        }
        public async Task<IActionResult> TimeTable(string date)
        {
           
            ConcertViewModel viewModel = new ConcertViewModel();
         
            viewModel.Concerts = await  _uow.ConcertRepository.GetAll().Include(c => c.Artist).Include(c => c.Stage).Include(t=>t.TimeSlot).Include(d=>d.DateDayFestival).Where(x=>x.DateDayFestival.Date==date).OrderBy(x=>x.TimeSlot.Hour).ToListAsync();
            viewModel.Artists = await _uow.ArtistRepository.GetAll().ToListAsync();
           
            foreach (var item in viewModel.Concerts)
            {
                viewModel.Concert =await _uow.ConcertRepository.GetById(item.Id);
                foreach (var item2 in viewModel.Artists)
                {
                    viewModel.Artist = await _uow.ArtistRepository.GetById(item2.Id);
                   
                }
              
            }
          
           

                viewModel.ArtistList = new SelectList(_uow.ArtistRepository.GetAll(), "Id", "Name");

       




            viewModel.Stages = new SelectList(_uow.StageRepository.GetAll(), "Id", "Name");
            viewModel.TimeSlots = new SelectList(_uow.TimeSlotRepository.GetAll(), "Id", "Hour");
            viewModel.DateDayFestivals = new SelectList(_uow.DateDayFestivalRepository.GetAll(), "Id", "Date");

            return View(viewModel);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Day1TimeTable()
        {
           
            await TimeTable("24/09/2021");
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Day2TimeTable()
        {
            await TimeTable("25/09/2021");
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Day3TimeTable()
        {
          
            await TimeTable("26/09/2021");
            return View();
        }
   
        public async Task<IActionResult> Day1TimeTableAdmin()
        {
          
           
            await TimeTable("24/09/2021");
          
            return View();
        }
        public async Task<IActionResult> Day2TimeTableAdmin()
        {

            await TimeTable("25/09/2021");
            return View();
        }
        public async Task<IActionResult> Day3TimeTableAdmin()
        {

            await TimeTable("26/09/2021");
            return View();
        }

        // GET: Concert/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _uow.ConcertRepository.GetAll()
                .Include(c => c.Artist)
                .Include(c => c.Stage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concert == null)
            {
                return NotFound();
            }

            return View(concert);
        }

        // GET: Concert/Create
        public IActionResult Create()
        {
            ConcertViewModel viewModel = new ConcertViewModel();
            viewModel.ArtistList = new SelectList(_uow.ArtistRepository.GetAll(), "Id", "Name");
            viewModel.Stages = new SelectList(_uow.StageRepository.GetAll(), "Id", "Name");
            viewModel.TimeSlots = new SelectList(_uow.TimeSlotRepository.GetAll(), "Id", "Hour");
            viewModel.DateDayFestivals = new SelectList(_uow.DateDayFestivalRepository.GetAll(), "Id", "Date");
            return View(viewModel);
        }

        // POST: Concert/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConcertViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Concerts = await _uow.ConcertRepository.GetAll().Include(c => c.Artist).Include(c => c.Stage).Include(t => t.TimeSlot).Include(d=>d.DateDayFestival).ToListAsync();
            //    viewModel.Artist = await _uow.ArtistRepository.GetAll().SingleOrDefaultAsync();
              //  viewModel.Concert = await _uow.ConcertRepository.GetAll().SingleOrDefaultAsync();

             

                    viewModel.Artists = await _uow.ArtistRepository.GetAll().ToListAsync();
                   


                        _uow.ConcertRepository.Create(viewModel.Concert);


                        await _uow.Save();
                if (viewModel.Concert.DateDayFestival.Date == "24/09/2021")
                {
                    // _notyf.Custom($"The Artist succesfull add to the timetable", 6, "white");
                    return RedirectToAction(nameof(Day1TimeTableAdmin));
                }
                if (viewModel.Concert.DateDayFestival.Date == "25/09/2021")
                {
                    //  _notyf.Custom($"The Artist succesfull add to the timetable", 6, "white");
                    return RedirectToAction(nameof(Day2TimeTableAdmin));
                }
                if (viewModel.Concert.DateDayFestival.Date == "26/09/2021")
                {
                    //   _notyf.Custom($"The Artist succesfull add to the timetable", 6, "white");
                    return RedirectToAction(nameof(Day3TimeTableAdmin));
                }



            }
            ViewData["DateID"] = new SelectList(_uow.DateDayFestivalRepository.GetAll(), "Id", "Date", viewModel.Concert.DateID);
            ViewData["ArtistID"] = new SelectList(_uow.ArtistRepository.GetAll(), "Id", "Name", viewModel.Concert.ArtistID);
            ViewData["StageID"] = new SelectList(_uow.StageRepository.GetAll(), "Id", "Name", viewModel.Concert.StageID);
            ViewData["TimeSlotID"] = new SelectList(_uow.TimeSlotRepository.GetAll(), "Id", "Hour", viewModel.Concert.TimeSlotID);
            return RedirectToAction(nameof(Day1TimeTableAdmin));
        }

        // GET: Concert/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var concert = await _uow.ConcertRepository.GetById(id);
          
            if (concert == null)
            {
                return NotFound();
            }
            ViewData["DateID"] = new SelectList(_uow.DateDayFestivalRepository.GetAll(), "Id", "Date", concert.DateID);
            ViewData["ArtistID"] = new SelectList(_uow.ArtistRepository.GetAll(), "Id", "Name", concert.ArtistID);
            ViewData["StageID"] = new SelectList(_uow.StageRepository.GetAll(), "Id", "Name", concert.StageID);
            ViewData["TimeSlotID"] = new SelectList(_uow.TimeSlotRepository.GetAll(), "Id", "Hour", concert.TimeSlotID);
            return View(concert);
        }

      //  POST: Concert/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
       //  more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateID,StageID,ArtistID,TimeSlotID")] Concert concert)
        {
            
            if (id != concert.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                

                try
                {
                    _uow.ConcertRepository.Update(concert);

                    await _uow.Save();
                 
                       
                    if (concert.DateID == 1)
                    {
                        // _notyf.Custom($"The Artist succesfull add to the timetable", 6, "white");
                        return RedirectToAction(nameof(Day1TimeTableAdmin));
                    }
                   
                    if (concert.DateID ==2)
                    {
                        //  _notyf.Custom($"The Artist succesfull add to the timetable", 6, "white");
                        return RedirectToAction(nameof(Day2TimeTableAdmin));
                    }
                  
                    if (concert.DateID==3)
                    {
                        //   _notyf.Custom($"The Artist succesfull add to the timetable", 6, "white");
                        return RedirectToAction(nameof(Day3TimeTableAdmin));
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcertExists(concert.Id))
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
            ViewData["DateID"] = new SelectList(_uow.DateDayFestivalRepository.GetAll(), "Id", "Date", concert.DateID);
            ViewData["ArtistID"] = new SelectList(_uow.ArtistRepository.GetAll(), "Id", "Name", concert.ArtistID);
            ViewData["StageID"] = new SelectList(_uow.StageRepository.GetAll(), "Id", "Name", concert.StageID);
            ViewData["TimeSlotID"] = new SelectList(_uow.TimeSlotRepository.GetAll(), "Id", "Hour", concert.TimeSlotID);
            return View(concert);
        }




        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concert = await _uow.ConcertRepository.GetAll()
                .Include(c => c.Artist)
                .Include(c => c.Stage)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concert == null)
            {
                return NotFound();
            }

            return View(concert);
        }

        // POST: Concert/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concert = await _uow.ConcertRepository.GetById(id);
            _uow.ConcertRepository.Delete(concert);

            await _uow.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcertExists(int id)
        {
            return _uow.ConcertRepository.GetAll().Any(e => e.Id == id);
        }


       


    }
}
