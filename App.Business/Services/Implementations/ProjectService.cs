using App.Business.Services.Interfaces;
using App.Business.ViewModels;
using App.Core;
using App.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repo;

        public ProjectService(IProjectRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Create(Project project)
        {
            if (await _repo.Create(project)) return true;
           return false;
        }

        public async Task Delete(int id)
        {
            await _repo.DeleteAsync(id);

        }

        public async Task<IQueryable<Project>> GetAllAsync()
        {
           var projects = await _repo.GetAllAsync();  return projects ;            
        }

        public async Task<Project> GetProject(int id)
        {
            if (id <= 0) throw new ArgumentException();
            var project = await _repo.GetById(id);
            return project;
        }

        public async Task Update(Project project)
        {
            if(project == null) throw new ArgumentNullException();
           await _repo.Update(project);

        }
    }
}
