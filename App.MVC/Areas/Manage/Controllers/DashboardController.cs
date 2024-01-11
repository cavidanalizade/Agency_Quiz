using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace App.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
/*    [Authorize(Roles = "Admin")]
*/
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
    
}
