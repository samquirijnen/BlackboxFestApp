﻿using BlackboxFest.Data.Repositories;
using BlackboxFest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<Artist> ArtistRepository { get; }
        IGenericRepository<News> NewsRepository { get; }
        IGenericRepository<Gallery> GalleryRepository { get; }
        IGenericRepository<Concert> ConcertRepository { get; }
        IGenericRepository<Stage> StageRepository { get; }
        IGenericRepository<TypeTicket> TypeTicketRepository { get; }
        IGenericRepository<TicketOrder> TicketOrderRepository { get; }
        IGenericRepository<TimeSlot> TimeSlotRepository { get; }
        IGenericRepository<CustomUser> UserRepository { get; }
        IGenericRepository<TicketOrderDetail> TicketOrderDetailRepository { get; }
        IGenericRepository<TicketShopCart> TicketShopCartRepository { get; }
        IGenericRepository<DateDayFestival> DateDayFestivalRepository { get; }

        Task Save();
    }
}
