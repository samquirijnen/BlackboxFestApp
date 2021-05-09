using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime BookingsDate { get; set; }
      
        public int TypeTicketId { get; set; }
        [ForeignKey("TypeTicketId")]
        public virtual TypeTicket Type { get; set; }
    }
}
