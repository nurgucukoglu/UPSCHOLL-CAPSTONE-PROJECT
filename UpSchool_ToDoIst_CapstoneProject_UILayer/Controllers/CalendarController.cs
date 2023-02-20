using Microsoft.AspNetCore.Mvc;

namespace UpSchool_ToDoIst_CapstoneProject_UILayer.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
