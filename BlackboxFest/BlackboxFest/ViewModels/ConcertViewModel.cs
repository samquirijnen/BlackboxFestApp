using BlackboxFest.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.ViewModels
{
    public class ConcertViewModel
    {
        public string EventSearch { get; set; }
        public string Options { get; set; }
        public Artist Artist { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public Concert Concert { get; set; }
        public IEnumerable<Concert> Concerts { get; set; }
        public Stage Stage { get; set; }
        public SelectList Stages { get; set; }
        public SelectList ArtistList { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public SelectList TimeSlots { get; set; }

    }
}
