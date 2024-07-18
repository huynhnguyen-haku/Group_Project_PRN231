using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs.ProductCategory;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryBusiness _categoryBusiness;
        public CategoryController()
        {
            _categoryBusiness = new CategoryBusiness();
        }

        [HttpGet(ApiEndPointConstant.Category.CategoriesEndPoint)]
        [SwaggerOperation(Summary = "Get all Categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _categoryBusiness.GetAllCategory();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Category.CategoryEndPoint)]
        [SwaggerOperation(Summary = "Get Category by its id")]
        public async Task<IActionResult> GetCategoryInfo(int id)
        {
            var response = await _categoryBusiness.GetCategoryInfo(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.Category.CategoryEndPoint)]
        [SwaggerOperation(Summary = "Update Category")]
        public async Task<IActionResult> UpdateCategoryInfo(int id, CategoryDTO category)
        {
            var response = await _categoryBusiness.UpdateCategoryInfo(id, category);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Category.CategoryEndPoint)]
        [SwaggerOperation(Summary = "Delete Category")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await _categoryBusiness.DeleteCategory(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Category.CategoriesEndPoint)]
        [SwaggerOperation(Summary = "Create a new Category")]
        public async Task<IActionResult> CreateCategory(CategoryDTO category)
        {
            var response = await _categoryBusiness.CreateCategory(category);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
