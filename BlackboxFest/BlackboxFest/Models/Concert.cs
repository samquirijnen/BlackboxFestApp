using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class Concert
    {
        public int Id { get; set; }
        public int DateID { get; set; }
        [ForeignKey("DateID")]
        public DateDayFestival DateDayFestival { get; set; }

        public int StageID { get; set; }
        [ForeignKey("StageID")]
        public Stage Stage { get; set; }
        public int? ArtistID { get; set; }
        [ForeignKey("ArtistID")]
        public Artist Artist { get; set; }
        public int? TimeSlotID { get; set; }
        [ForeignKey("TimeSlotID")]
        public TimeSlot TimeSlot { get; set; }
      
    }
}
