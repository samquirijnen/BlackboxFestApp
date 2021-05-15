using BlackboxFest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.ViewModels
{
    public class TicketShopCartViewModel
    {
      
        public TypeTicket TypeTicket { get; set; }
        public IEnumerable<TypeTicket> TypeTickets { get; set; }
        public TicketShopCart TicketShopCart { get; set; }
        public List<TicketShopCart> TicketShopCarts { get; set; }
        public TicketOrderDetail ticketOrderDetail { get; set; }
        public List<TicketOrderDetail> ticketOrderDetails { get; set; }
        public double TotaalAantal { get; set; }
        public int TotaalTickets { get; set; }

    }
}
