using BlackboxFest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.ViewModels
{
    public class NewsViewModel
    {
        public News News { get; set; }
        public List<News> NewsItems { get; set; }

        public UserNews UserNews { get; set; }
        public List<UserNews> UserNewsItems { get; set; }

     
        
    
    }
}
