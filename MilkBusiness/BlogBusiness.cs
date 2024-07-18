using Microsoft.EntityFrameworkCore;
using MilkData.DTOs.Blog;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class BlogBusiness
    {
        private UnitOfWork _unitOfWork;

        public BlogBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<IMilkResult> GetAllBlog()
        {
            var blogList = await _unitOfWork.GetRepository<Blog>().GetListAsync(
                selector: x => new GetBlogDTO
                {
                    BlogId = x.BlogId,
                    AccountId = x.AccountId,
                    BlogContent = x.BlogContent,
                    CategoryName = x.CategoryName,
                    CreatedDate = x.CreatedDate,
                    ImageUrl = x.ImageUrl,
                    Priority = x.Priority,
                    ProductSuggestUrl = x.ProductSuggestUrl,
                    Reference = x.Reference,
                    Title = x.Title,
                    UpdateDate = x.UpdateDate
                });
            return new MilkResult(blogList);
        }

        public async Task<IMilkResult> GetBlogInfo(int blogId)
        {
            var blog = await _unitOfWork.GetRepository<Blog>()
                .SingleOrDefaultAsync(predicate: b => b.BlogId == blogId,
                                      selector: x => new GetBlogDTO
                                      {
                                          BlogId = x.BlogId,
                                          AccountId = x.AccountId,
                                          BlogContent = x.BlogContent,
                                          CategoryName = x.CategoryName,
                                          CreatedDate = x.CreatedDate,
                                          ImageUrl = x.ImageUrl,
                                          Priority = x.Priority,
                                          ProductSuggestUrl = x.ProductSuggestUrl,
                                          Reference = x.Reference,
                                          Title = x.Title,
                                          UpdateDate = x.UpdateDate
                                      });
            return new MilkResult(blog);
        }

        public async Task<IMilkResult> CreateBlog(BlogDTO blog)
        {
            MilkResult result = new MilkResult();

            Blog createdBlog = new Blog()
            {
                AccountId = blog.AccountId,
                BlogContent = blog.BlogContent,
                CategoryName = blog.CategoryName,
                CreatedDate = DateTime.Now,
                ImageUrl = blog.ImageUrl,
                Priority = blog.Priority,
                ProductSuggestUrl = blog.ProductSuggestUrl,
                Reference = blog.Reference,
                Title = blog.Title,
                UpdateDate = DateTime.Now
            };

            await _unitOfWork.GetRepository<Blog>().InsertAsync(createdBlog);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            if (!isSuccessful)
            {
                result.Status = -1;
                result.Message = "Create unsuccessfully";
            }
            else
            {
                result = new MilkResult(1, "Create Susscessfull");
            }

            return result;
        }

        public async Task<IMilkResult> UpdateBlogInfo(int id, BlogDTO blogInfo)
        {
            Blog currentBlog = await _unitOfWork.GetRepository<Blog>()
                .SingleOrDefaultAsync(predicate: b => b.BlogId == id);
            if (currentBlog == null) return new MilkResult(-1, "Blog cannot be found");
            else
            {
                currentBlog.Title = String.IsNullOrEmpty(blogInfo.Title) ? currentBlog.Title : blogInfo.Title;
                currentBlog.BlogContent = String.IsNullOrEmpty(blogInfo.BlogContent) ? currentBlog.BlogContent : blogInfo.BlogContent;
                currentBlog.ImageUrl = String.IsNullOrEmpty(blogInfo.ImageUrl) ? currentBlog.ImageUrl : blogInfo.ImageUrl;
                currentBlog.ProductSuggestUrl = String.IsNullOrEmpty(blogInfo.ProductSuggestUrl) ? currentBlog.ProductSuggestUrl : blogInfo.ProductSuggestUrl;
                currentBlog.CategoryName = String.IsNullOrEmpty(blogInfo.CategoryName) ? currentBlog.CategoryName : blogInfo.CategoryName;
                currentBlog.Reference = String.IsNullOrEmpty(blogInfo.Reference) ? currentBlog.Reference : blogInfo.Reference;
                currentBlog.ImageUrl = String.IsNullOrEmpty(blogInfo.ImageUrl) ? currentBlog.ImageUrl : blogInfo.ImageUrl;
                currentBlog.AccountId = blogInfo.AccountId;
                currentBlog.Priority = blogInfo.Priority;
                currentBlog.UpdateDate = DateTime.Now;

                _unitOfWork.GetRepository<Blog>().UpdateAsync(currentBlog);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(blogInfo);
        }

        public async Task<IMilkResult> DeleteBlog(int blogId)
        {
            Blog blog = await _unitOfWork.GetRepository<Blog>()
                .SingleOrDefaultAsync(predicate: b => b.BlogId == blogId);
            if (blog == null) return new MilkResult();
            else
            {
                _unitOfWork.GetRepository<Blog>().DeleteAsync(blog);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult(1, "Delete Successfull");
        }
    }
}
