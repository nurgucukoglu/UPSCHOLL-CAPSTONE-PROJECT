using Microsoft.AspNetCore.Mvc;

namespace UpSchool_ToDoIst_CapstoneProject_UILayer.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
