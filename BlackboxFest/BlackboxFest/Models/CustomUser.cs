using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlackboxFest.Models
{
    public class CustomUser : IdentityUser
    {
        [Required(ErrorMessage = "Oops you don't give up a firstname.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Oops you don't give up a lastname.")]
        public string LastName { get; set; }

        public int? TicketId { get; set; }
        [ForeignKey("TicketId")]
        public virtual Ticket GetTicket { get; set; }

    }
}
