using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.Models
{
    public class TicketOrderDetail
    {
        public int Id { get; set; }
        public int TicketOrderId { get; set; }
        [ForeignKey("TicketOrderId")]
        public TicketOrder TicketOrder { get; set; }
        public int TypeTicketId { get; set; }
        [ForeignKey("TypeTicketId")]
        public TypeTicket TypeTicket { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        [NotMapped]
        public string Name { get; set; }
        public TicketOrderDetail()
        {

        }

        public TicketOrderDetail(TypeTicket typeTicket)
        {
            Id = typeTicket.Id;
            Count = 1;
            Price = typeTicket.Price * Count;
            Name = typeTicket.Name;
            
        }
    }
}
