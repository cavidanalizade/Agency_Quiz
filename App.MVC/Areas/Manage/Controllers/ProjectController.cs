using App.Business.Helper;
using App.Business.Services.Interfaces;
using App.Core;
using App.MVC.Areas.Manage.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace App.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
/*    [Authorize(Roles = "Admin")]
*/
    public class ProjectController : Controller
    {
        private readonly IProjectService _service;
        private readonly IWebHostEnvironment _env;


        public ProjectController(IProjectService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            IQueryable<Project> ProjectList = await _service.GetAllAsync();

            return View(ProjectList);
        }

        public IActionResult Create()
        {
            return  View();
        }
        [HttpPost]

        public async Task<IActionResult> CreateAsync(CreateProjectVM createProjectVM)
        {
            if (createProjectVM is null) return NotFound();
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!createProjectVM.Image.CheckContent("image/"))
            {
                ModelState.AddModelError("Image", "Duzgun format daxil edin");
                return View();
            }
            Project project = new Project() 
            { 
                Title = createProjectVM.Title ,
                CategoryName = createProjectVM.CategoryName ,
                ImageUrl = createProjectVM.Image.UploadFile(_env.WebRootPath, "/Upload/Project/") ,
                IsDeleted= false ,
                CreatedAt = DateTime.Now
            };
            if( await _service.Create(project)) return RedirectToAction(actionName:"Index" , controllerName:"Project");
            return View(project);
        }
        public async Task<IActionResult> Update(int id)
        {
            Project project = await _service.GetProject(id);
            UpdateProjectVM updateProjectVM = new UpdateProjectVM()
            {
                Id = id,
                Title = project.Title ,
                CategoryName=project.CategoryName ,
                ImageUrl = project.ImageUrl,
            };
            return View (updateProjectVM);

        }




        [HttpPost]
        public async Task<IActionResult> Update(UpdateProjectVM updateProjectVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
           
            Project project = await _service.GetProject(updateProjectVM.Id);
            project.Title = updateProjectVM.Title;
            project.CategoryName = updateProjectVM.CategoryName;
            project.ImageUrl = updateProjectVM.Image.UploadFile(_env.WebRootPath, "/Upload/Project/");



            await _service.Update(project);


            return RedirectToAction(nameof(Index));
        }


        public async Task <IActionResult> Delete (int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
