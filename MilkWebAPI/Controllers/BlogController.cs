using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs.Blog;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogBusiness _blogBusiness;

        public BlogController()
        {
            _blogBusiness = new BlogBusiness();
        }

        [HttpGet(ApiEndPointConstant.Blog.BlogsEndpoint)]
        [SwaggerOperation(Summary = "Get all Blogs")]
        public async Task<IActionResult> GetAllBlogs()
        {
            var response = await _blogBusiness.GetAllBlog();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Blog.BlogEndpoint)]
        [SwaggerOperation(Summary = "Get Blog by its id")]
        public async Task<IActionResult> GetBlogInfo(int id)
        {
            var response = await _blogBusiness.GetBlogInfo(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Blog.BlogsEndpoint)]
        [SwaggerOperation(Summary = "Create a new Blog")]
        public async Task<IActionResult> CreateBlog(BlogDTO blog)
        {
            var response = await _blogBusiness.CreateBlog(blog);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.Blog.BlogEndpoint)]
        [SwaggerOperation(Summary = "Update Blog Info")]
        public async Task<IActionResult> UpdateBlogInfo(int id, BlogDTO blog)
        {
            var response = await _blogBusiness.UpdateBlogInfo(id, blog);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Blog.BlogEndpoint)]
        [SwaggerOperation(Summary = "Delete Blog")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var response = await _blogBusiness.DeleteBlog(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
