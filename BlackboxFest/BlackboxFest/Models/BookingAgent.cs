using System;
using System.ComponentModel.DataAnnotations;

namespace BlackboxFest.Models
{
    public class BookingAgent
    {
        public int Id { get; set; }
        [Required]
        public string FirstName  { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAdress { get; set; }
        [Required]
        public string phoneNumber { get; set; }
    }
}
