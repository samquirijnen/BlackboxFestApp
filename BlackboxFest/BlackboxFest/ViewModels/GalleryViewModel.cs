using BlackboxFest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.ViewModels
{
    public class GalleryViewModel
    {
        public IEnumerable<Gallery> Galleries { get; set; }
        public Gallery Gallery { get; set; }
    }
}
