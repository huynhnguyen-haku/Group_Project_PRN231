using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs.Product;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductBusiness _productBusiness;
        public ProductController()
        {
            _productBusiness = new ProductBusiness();
        }

        [HttpGet(ApiEndPointConstant.Product.ProductsEndPoint)]
        [SwaggerOperation(Summary = "Get all Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productBusiness.GetAllProduct();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Product.ProductEndPoint)]
        [SwaggerOperation(Summary = "Get Product by its id")]
        public async Task<IActionResult> GetProductInfo(int id)
        {
            var response = await _productBusiness.GetProductInfo(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Product.ProductsEndPoint)]
        [SwaggerOperation(Summary = "Create a new Product")]
        public async Task<IActionResult> CreateProduct(ProductDTO product)
        {
            var response = await _productBusiness.CreateProduct(product);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.Product.ProductEndPoint)]
        [SwaggerOperation(Summary = "Update Product Info")]
        public async Task<IActionResult> UpdateProductInfo(int id, ProductDTO product)
        {
            var response = await _productBusiness.UpdateProductInfo(id, product);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Product.ProductEndPoint)]
        [SwaggerOperation(Summary = "Delete Product by its id")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productBusiness.DeleteProduct(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
