using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

namespace MilkWebApp.Controllers;

public class LoginController : Controller
{
    private readonly string apiUrl = "https://localhost:7120/api/v1/";

    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> LoginRequest(string email, string password)
    {
        if (string.IsNullOrEmpty(email))
        {
            string err = "Empty email";
        }
        if (string.IsNullOrEmpty(password))
        {
            string err = "Empty password";
        }

        Console.WriteLine("Email: " + email, "Password: " + password);

        return null;

        //try
        //{
        //    string result = "";
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync(apiUrl + "login?email=" + email + "&password=" + password))
        //        {
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var content = await response.Content.ReadAsStringAsync();
        //                result = JsonConvert.DeserializeObject<string>(content);
        //                Console.WriteLine(result);
        //            }
        //        }
        //    }
        //    return result;
        //}
        //catch (Exception ex)
        //{
        //    throw new Exception(ex.Message);
        //}
    }
}
