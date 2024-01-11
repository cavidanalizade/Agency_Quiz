using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Common
{
    public class BaseAuditable:BaseEntity
    {
        public DateTime? CreatedAt { get; set; } =DateTime.Now;
        public bool IsDeleted { get; set; } = false;

    }
}
