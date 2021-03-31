using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class UserConcert
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual CustomUser CustomUser { get; set; }
        public int? ConcertId { get; set; }
        [ForeignKey("ConcertId")]
        public virtual Concert Concert { get; set; }
    }
}
