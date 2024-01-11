using App.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.ViewModels
{
    public class ProjectListVM
    {
        public IQueryable<Project> projects { get; set; }
    }
}
