using App.Business.Services.Interfaces;
using App.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace App.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectService _service;

        public HomeController(IProjectService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            IQueryable<Project> ProjectList = await _service.GetAllAsync();

            return View(ProjectList);
        }
    }
}