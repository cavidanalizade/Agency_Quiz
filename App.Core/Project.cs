using App.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public class Project:BaseAuditable
    {
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public string? CategoryName { get; set; }

    }
}
