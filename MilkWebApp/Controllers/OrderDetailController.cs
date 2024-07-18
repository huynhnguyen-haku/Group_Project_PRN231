using Microsoft.AspNetCore.Mvc;
using MilkData.DTOs;
using MilkData.Models;
using MilkWebApp.Models;
using Newtonsoft.Json;

namespace MilkWebApp.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly string apiUrl = "https://localhost:7120/api/v1/order-details";

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<OrderDetail>> GetList()
        {
            try
            {
                var result = new List<OrderDetail>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<List<OrderDetail>>(content);
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
                var result = new OrderDetail();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + $"/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<OrderDetail>(content);
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
                var result = new OrderDetail();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(apiUrl + $"/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<OrderDetail>(content);
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

        //[HttpPost]
        //public async Task<MilkResult> Save(OrderDetailDTO orderDetail)
        //{
        //    try
        //    {
        //        MilkResult result = new MilkResult();
        //        using (var httpClient = new HttpClient())
        //        {
        //            //Set condition
        //            switch (orderDetail.HttpMethod)
        //            {
        //                case "POST":
        //                    using (var response = await httpClient.PostAsJsonAsync(apiUrl, orderDetail))
        //                    {
        //                        if (response.IsSuccessStatusCode)
        //                        {
        //                            var content = await response.Content.ReadAsStringAsync();
        //                            result = JsonConvert.DeserializeObject<MilkResult>(content);
        //                        }
        //                    }
        //                    break;
        //                case "PUT":
        //                    using (var response = await httpClient.PutAsJsonAsync(apiUrl + $"/{orderDetail.OrderDetailId}", orderDetail))
        //                    {
        //                        if (response.IsSuccessStatusCode)
        //                        {
        //                            var content = await response.Content.ReadAsStringAsync();
        //                            result = JsonConvert.DeserializeObject<MilkResult>(content);
        //                        }
        //                    }
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
