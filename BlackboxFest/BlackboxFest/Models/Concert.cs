using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlackboxFest.Models
{
    public class Concert
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DisplayName("Begin Time")]
        [Required]
        public DateTime BeginTime { get; set; }
        
        [Required]
        public DateTime EndTime { get; set; }
    }
}
