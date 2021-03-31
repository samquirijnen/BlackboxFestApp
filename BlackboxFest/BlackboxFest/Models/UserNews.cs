using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class UserNews
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual CustomUser CustomUser { get; set; }
        public int? NewsId { get; set; }
        [ForeignKey("NewsId")]
        public virtual IEnumerable<News> News { get; set; }
    }
}
