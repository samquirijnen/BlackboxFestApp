using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class TicketOrder
    {
        public int Id { get; set; }
        public DateTime BookingsDate { get; set; }
        public string CustomUserID { get; set; }
        [ForeignKey("CustomUserID")]
        public CustomUser CustomUser { get; set; }
        [Required]
        public double OrderTotal { get; set; }
        public string  OrderStatus { get; set; }
        public string PaymentStatus { get; set; }

    }
}
