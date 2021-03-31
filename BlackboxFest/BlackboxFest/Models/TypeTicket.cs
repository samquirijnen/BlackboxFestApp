using System;
using System.ComponentModel.DataAnnotations;

namespace BlackboxFest.Models
{
    public class TypeTicket
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
