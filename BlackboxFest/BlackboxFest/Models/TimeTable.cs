using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class TimeTable
    {
        public int Id { get; set; }
        [Required]
        public int ConcertId { get; set; }
        [ForeignKey("ConcertId")]
        public virtual IEnumerable<Concert> Concerts { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist  Artists { get; set; }
    }
}
