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
        private IGenericRepository<TicketOrder> ticketOrderRepository;
        private IGenericRepository<TicketOrderDetail> ticketOrderDetailRepository;
        private IGenericRepository<TicketShopCart> ticketShopCartRepository;
        private IGenericRepository<TimeSlot> timeSlotRepository;
        private IGenericRepository<CustomUser> userRepository;
        private IGenericRepository<DateDayFestival> dateRepository;
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
        public IGenericRepository<TicketOrder> TicketOrderRepository
        {
            get
            {
                if (ticketOrderRepository == null)
                {
                    ticketOrderRepository = new GenericRepository<TicketOrder>(_context);
                }
                return ticketOrderRepository;
            }

        }
        public IGenericRepository<TicketShopCart> TicketShopCartRepository
        {
            get
            {
                if (ticketShopCartRepository == null)
                {
                    ticketShopCartRepository = new GenericRepository<TicketShopCart>(_context);
                }
                return ticketShopCartRepository;
            }

        }
        public IGenericRepository<TicketOrderDetail> TicketOrderDetailRepository
        {
            get
            {
                if (ticketOrderDetailRepository == null)
                {
                    ticketOrderDetailRepository = new GenericRepository<TicketOrderDetail>(_context);
                }
                return ticketOrderDetailRepository;
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
        public IGenericRepository<CustomUser> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new GenericRepository<CustomUser>(_context);
                }
                return userRepository;
            }

        }
        public IGenericRepository<DateDayFestival> DateDayFestivalRepository
        {
            get
            {
                if (dateRepository == null)
                {
                    dateRepository = new GenericRepository<DateDayFestival>(_context);
                }
                return dateRepository;
            }

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
