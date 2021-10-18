using Microsoft.AspNetCore.Mvc;

namespace CalendarEvent.Controllers
{
    public class AdminController : Controller
    {
        [Route("Admin/Calendar")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
