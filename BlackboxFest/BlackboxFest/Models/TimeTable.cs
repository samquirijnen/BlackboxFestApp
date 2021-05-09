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
        public virtual Concert Concert { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public virtual Artist  Artist { get; set; }
    }
}
