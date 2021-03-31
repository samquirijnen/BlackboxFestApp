using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlackboxFest.Models
{
    public class CustomUser : IdentityUser
    {
       
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
       // public DateTime DateOfBirth { get; set; }
        public int? TicketId { get; set; }
        [ForeignKey("TicketId")]
        public virtual Ticket GetTicket { get; set; }

    }
}
