﻿using BlackboxFest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.ViewModels
{
    public class ArtistViewModel
    {
        public string EventSearch { get; set; }
        public string Options { get; set; }
        public Artist Artist { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
        public List<Concert>Concerts { get; set; }
      
    }
}
