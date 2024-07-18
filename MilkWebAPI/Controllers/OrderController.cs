using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs;
using MilkData.DTOs.Blog;
using MilkData.DTOs.Order;
using MilkData.Models;
using MilkData.VNPay.Response;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;
using static MilkData.DTOs.Order.OrderDTO;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderBusiness _orderBusiness;

        public OrderController()
        {
            _orderBusiness = new OrderBusiness();
        }

        [HttpGet(ApiEndPointConstant.Order.OrdersEndPoint)]
        [SwaggerOperation(Summary = "Get all Orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var response = await _orderBusiness.GetAllOrders();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Order.OrderEndPoint)]
        [SwaggerOperation(Summary = "Get Order by its id")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var response = await _orderBusiness.GetOrderById(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Order.OrdersEndPoint)]
        [SwaggerOperation(Summary = "Create a new Order")]
        public async Task<IActionResult> CreateOrder(OrderDTO.CreateOrder createOrder)
        {
            var response = await _orderBusiness.CreateOrder(createOrder);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.Order.OrderEndPoint)]
        [SwaggerOperation(Summary = "Update Order Info")]
        public async Task<IActionResult> UpdateOrderInfo(int id, UpdateOrder order)
        {
            var response = await _orderBusiness.UpdateOrder(id, order);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Order.OrderEndPoint)]
        [SwaggerOperation(Summary = "Delete Order")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var response = await _orderBusiness.DeleteOrder(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
