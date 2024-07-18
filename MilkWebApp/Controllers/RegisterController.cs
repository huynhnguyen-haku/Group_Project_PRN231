using Microsoft.AspNetCore.Mvc;

namespace MilkWebApp.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
