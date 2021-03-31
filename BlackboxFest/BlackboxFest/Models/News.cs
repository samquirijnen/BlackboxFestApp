using System;
using System.ComponentModel.DataAnnotations;

namespace BlackboxFest.Models
{
    public class News
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public  DateTime Date{ get; set; }
    }
}
