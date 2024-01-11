using App.Business.ViewModels;
using App.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IQueryable<Project>> GetAllAsync();
        Task<bool> Create(Project project);
        Task<Project> GetProject(int id);
        Task Update(Project project);
        Task Delete(int id);

    }
}
