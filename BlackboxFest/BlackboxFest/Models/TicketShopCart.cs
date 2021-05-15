using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.Models
{
    public class TicketShopCart
    {
        public TicketShopCart()
        {
            CountTypeTickets = 1;
        }
        [Key]
        public int TicketId { get; set; }
        public string CustomUserID { get; set; }
        [ForeignKey("CustomUserID")]
        public CustomUser CustomUser { get; set; }
        public int TypeTicketID { get; set; }
        [ForeignKey("TypeTicketID")]
        public TypeTicket TypeTicket { get; set; }
        [Range(1,10,ErrorMessage ="Your are can't have more than 10 tickets per person")]
        public int CountTypeTickets { get; set; }
        [NotMapped]
        public double PriceAllTickets { get; set; }

    }
}
