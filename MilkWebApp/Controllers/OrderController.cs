using Microsoft.AspNetCore.Mvc;
using MilkData.DTOs;
using MilkData.Models;
using MilkWebApp.Models;
using MilkWebApp.Models.Order;
using Newtonsoft.Json;

namespace MilkWebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly string apiUrl = "https://localhost:7120/api/v1/orders";

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Order>> GetList()
        {
            try
            {
                var result = new List<Order>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<Order>>(content);
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult AddNew()
        {
            return PartialView("Add");
        }

        [HttpPost]
        public async Task<IActionResult> Detail(string id)
        {
            try
            {
                var result = new Order();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + $"/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<Order>(content);
                        }
                    }
                }

                return PartialView("Detail", result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id)
        {
            try
            {
                var result = new Order();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + $"/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<Order>(content);
                        }
                    }
                }

                return PartialView("Edit", result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<MilkResult> Delete(string id)
        {
            try
            {
                MilkResult result = new MilkResult();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(apiUrl + $"/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<MilkResult>(content);
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<MilkResult> Save(OrderModel order)
        {
            try
            {
                MilkResult result = new MilkResult();
                using (var httpClient = new HttpClient())
                {
                    //Set condition
                    switch (order.HttpMethod)
                    {
                        case "POST":
                            using (var response = await httpClient.PostAsJsonAsync(apiUrl, order))
                            {
                                if (response.IsSuccessStatusCode)
                                {
                                    var content = await response.Content.ReadAsStringAsync();
                                    result = JsonConvert.DeserializeObject<MilkResult>(content);
                                }
                            }
                            break;
                        case "PUT":
                            using (var response = await httpClient.PutAsJsonAsync(apiUrl + $"/{order.OrderId}", order))
                            {
                                if (response.IsSuccessStatusCode)
                                {
                                    var content = await response.Content.ReadAsStringAsync();
                                    result = JsonConvert.DeserializeObject<MilkResult>(content);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
