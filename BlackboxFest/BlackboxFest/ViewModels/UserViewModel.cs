using BlackboxFest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.ViewModels
{
    public class UserViewModel
    {
        public CustomUser User { get; set; }
        public IEnumerable<CustomUser> Users { get; set; }
        public TicketOrder TicketOrder { get; set; }
        public IEnumerable<TicketOrder> TicketOrders { get; set; }
    }
}
