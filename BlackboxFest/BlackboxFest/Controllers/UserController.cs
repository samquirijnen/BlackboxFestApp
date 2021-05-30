using BlackboxFest.Data;
using BlackboxFest.Data.UnitOfWork;
using BlackboxFest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackboxFest.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _uow;
        public UserController(IUnitOfWork uow)
        {
            _uow = uow;
        }
       
        public async Task<IActionResult> Index()
        {
            UserViewModel viewModel = new UserViewModel();
            viewModel.Users =await _uow.UserRepository.GetAll().ToListAsync();
           
          
            return View(viewModel);
        }
    }
}
