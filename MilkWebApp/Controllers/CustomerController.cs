using Microsoft.AspNetCore.Mvc;

namespace MilkWebApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Browse()
        {
            return View();
        }

        [Route("Customer/Profile")]
        public IActionResult PersonalInfo()
        {
            return View("~/Views/Customer/Profile/PersonalInfo.cshtml");
        }

        [Route("Customer/Profile/ChangePwd")]
        public IActionResult ChangePwd()
        {
            return View("~/Views/Customer/Profile/ChangePwd.cshtml");
        }

        [Route("Customer/Profile/Addresses")]
        public IActionResult Addresses()
        {
            return View("~/Views/Customer/Profile/Addresses.cshtml");
        }

        [Route("Customer/Profile/Orders")]
        public IActionResult Orders()
        {
            return View("~/Views/Customer/Profile/Orders.cshtml");
        }

        [Route("Customer/Profile/Vouchers")]
        public IActionResult Vouchers()
        {
            return View("~/Views/Customer/Profile/Vouchers.cshtml");
        }
    }
}
