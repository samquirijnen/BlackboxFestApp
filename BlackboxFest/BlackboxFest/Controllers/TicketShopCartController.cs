using BlackboxFest.Data.UnitOfWork;
using BlackboxFest.Models;
using BlackboxFest.Sessions;
using BlackboxFest.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlackboxFest.Controllers
{
    [Authorize]
    public class TicketShopCartController : Controller
    {
        private readonly IUnitOfWork _uow;
        public TicketShopCartController(IUnitOfWork uow)
        {
            _uow = uow;
        }
     
        public async Task<IActionResult> Index()
        {
            TicketShopCartViewModel viewModel = new TicketShopCartViewModel();
            viewModel.TypeTickets = await _uow.TypeTicketRepository.GetAll().ToListAsync();

           
            return View(viewModel);
        }
        public IActionResult BuyView(int id)
        {

            TicketShopCartViewModel viewModel = new TicketShopCartViewModel();
            
            var count = 0;
            HttpContext.Session.SetInt32("TicketShopCart", count);
            Clear();

            return View(viewModel);
        }
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("TickeShopCart");
            return View();
        }

        public IActionResult TicketShopCartOverview()
        {

            List<TicketOrderDetail> ticketCartDetail = HttpContext.Session.GetJson<List<TicketOrderDetail>>("TickeShopCart") ??new List<TicketOrderDetail>();
            TicketShopCartViewModel viewModel = new TicketShopCartViewModel
            {
                ticketOrderDetails = ticketCartDetail,
                TotaalAantal = ticketCartDetail.Sum(x => x.Price * x.Count),
                
                
            };
           
            return View(viewModel);


        }
        [HttpPost]

        public async Task<IActionResult> AddToCart(TicketShopCartViewModel viewModel,int id)
        {

           viewModel.TypeTicket = await _uow.TypeTicketRepository.GetById(id);
           viewModel.ticketOrderDetails = HttpContext.Session.GetJson<List<TicketOrderDetail>>("TickeShopCart") ?? new List<TicketOrderDetail>();
            viewModel.ticketOrderDetail = viewModel.ticketOrderDetails.Where(x => x.TypeTicketId == id).FirstOrDefault();

            if (viewModel.ticketOrderDetail == null)
            {
               
                viewModel.ticketOrderDetails.Add(new TicketOrderDetail(viewModel.TypeTicket));
            }
            else
            {
                viewModel.ticketOrderDetail.Count += 1;
             
            }
            HttpContext.Session.SetJson("TickeShopCart", viewModel.ticketOrderDetails);
              var count = viewModel.ticketOrderDetails.Count();
          
            HttpContext.Session.SetInt32("TicketShopCart", count);
            return RedirectToAction(nameof(Index));
        }





        public IActionResult Remove(TicketShopCartViewModel viewModel, int id)
        {

          
            if (HttpContext.Session.GetJson<List<TicketOrderDetail>>("TickeShopCart") != null && HttpContext.Session.GetJson<List<TicketOrderDetail>>("TickeShopCart").Count() > 0)
            {
                viewModel.ticketOrderDetails = HttpContext.Session.GetJson<List<TicketOrderDetail>>("TickeShopCart");

            }

            viewModel.ticketOrderDetails.Remove(viewModel.ticketOrderDetails.FirstOrDefault(x => x.Id == id));
            HttpContext.Session.SetJson("TickeShopCart", viewModel.ticketOrderDetails);
            var count = viewModel.ticketOrderDetails.Count();

            HttpContext.Session.SetInt32("TicketShopCart", count);
            return RedirectToAction(nameof(TicketShopCartOverview));
        }

    }
}
