using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.Infrastructure
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
          
            return View();
        }
    }
}
