using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackboxFest.Models
{
    public class Stage
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ConcertId { get; set; }
        public virtual IEnumerable<Concert> Concert { get; set; }

    }
}
