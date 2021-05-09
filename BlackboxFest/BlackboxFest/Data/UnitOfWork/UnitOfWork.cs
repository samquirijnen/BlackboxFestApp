using BlackboxFest.Data.Repositories;
using BlackboxFest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private  IGenericRepository<Artist> artistRepository;
        private IGenericRepository<News> newsRepository;
        private IGenericRepository<Gallery> galleryRepository;
        private IGenericRepository<Concert> concertRepository;
        private IGenericRepository<Stage> stageRepository;
        private IGenericRepository<TypeTicket> typeTicketRepository;
        private IGenericRepository<Ticket> ticketRepository;
        private IGenericRepository<TimeSlot> timeSlotRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<Artist> ArtistRepository 
        {
            get
            {
                if (artistRepository == null)
                {
                    artistRepository = new GenericRepository<Artist>(_context);
                }
                return artistRepository;
            }
        
        }
        public IGenericRepository<News> NewsRepository
        {
            get
            {
                if (newsRepository == null)
                {
                    newsRepository = new GenericRepository<News>(_context);
                }
                return newsRepository;
            }

        }
        public IGenericRepository<Gallery> GalleryRepository
        {
            get
            {
                if (galleryRepository == null)
                {
                    galleryRepository = new GenericRepository<Gallery>(_context);
                }
                return galleryRepository;
            }

        }
        public IGenericRepository<Concert> ConcertRepository
        {
            get
            {
                if (concertRepository == null)
                {
                    concertRepository = new GenericRepository<Concert>(_context);
                }
                return concertRepository;
            }

        }
        public IGenericRepository<Stage> StageRepository
        {
            get
            {
                if (stageRepository == null)
                {
                    stageRepository = new GenericRepository<Stage>(_context);
                }
                return stageRepository;
            }

        }
        public IGenericRepository<TypeTicket> TypeTicketRepository
        {
            get
            {
                if (typeTicketRepository == null)
                {
                    typeTicketRepository = new GenericRepository<TypeTicket>(_context);
                }
                return typeTicketRepository;
            }

        }
        public IGenericRepository<Ticket> TicketRepository
        {
            get
            {
                if (ticketRepository == null)
                {
                    ticketRepository = new GenericRepository<Ticket>(_context);
                }
                return ticketRepository;
            }

        }
        public IGenericRepository<TimeSlot> TimeSlotRepository
        {
            get
            {
                if (timeSlotRepository == null)
                {
                    timeSlotRepository = new GenericRepository<TimeSlot>(_context);
                }
                return timeSlotRepository;
            }

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
