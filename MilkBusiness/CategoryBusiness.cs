using MilkData.DTOs.ProductCategory;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class CategoryBusiness
    {
        private UnitOfWork _unitOfWork;
        public CategoryBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        //Get all categories
        public async Task<IMilkResult> GetAllCategory()
        {
            var categoryList = await _unitOfWork.GetRepository<Category>()
                .GetListAsync(selector: x => new GetCategoryDTO
                {
                    CategoryName = x.CategoryName,
                    CategoryCode = x.CategoryCode,
                    CategoryId = x.CategoryId,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Status = x.Status
                });
            return new MilkResult(categoryList);
        }

        //Get category by id
        public async Task<IMilkResult> GetCategoryInfo(int categoryId)
        {
            var category = await _unitOfWork.GetRepository<Category>()
                .SingleOrDefaultAsync(predicate: c => c.CategoryId == categoryId,
                                      selector: x => new GetCategoryDTO
                                      {
                                          CategoryName = x.CategoryName,
                                          CategoryCode = x.CategoryCode,
                                          CategoryId = x.CategoryId,
                                          Description = x.Description,
                                          ImageUrl = x.ImageUrl,
                                          Status = x.Status
                                      });
            return new MilkResult(category);
        }

        //Update category info
        public async Task<IMilkResult> UpdateCategoryInfo(int id, CategoryDTO categoryInfo)
        {
            Category currentCategory = await _unitOfWork.GetRepository<Category>()
                .SingleOrDefaultAsync(predicate: c => c.CategoryId == id);
            if (currentCategory == null) return new MilkResult(-1, "Category cannot be found");
            else
            {
                currentCategory.CategoryName = String.IsNullOrEmpty(categoryInfo.CategoryName) ? currentCategory.CategoryName : categoryInfo.CategoryName;
                currentCategory.Description = String.IsNullOrEmpty(categoryInfo.Description) ? currentCategory.Description : categoryInfo.Description;
                currentCategory.CategoryCode = String.IsNullOrEmpty(categoryInfo.CategoryCode) ? currentCategory.CategoryCode : categoryInfo.CategoryCode;
                currentCategory.ImageUrl = String.IsNullOrEmpty(categoryInfo.ImageUrl) ? currentCategory.ImageUrl : categoryInfo.ImageUrl;
                currentCategory.Status = String.IsNullOrEmpty(categoryInfo.Status) ? currentCategory.Status : categoryInfo.Status;

                _unitOfWork.GetRepository<Category>().UpdateAsync(currentCategory);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult(categoryInfo);
        }

        //Delete category
        public async Task<IMilkResult> DeleteCategory(int categoryId)
        {
            Category category = await _unitOfWork.GetRepository<Category>()
                .SingleOrDefaultAsync(predicate: c => c.CategoryId == categoryId);
            if (category == null) return new MilkResult();
            else
            {
                _unitOfWork.GetRepository<Category>().DeleteAsync(category);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult(1, "Delete Successfull");
        }

        //Create category
        public async Task<IMilkResult> CreateCategory(CategoryDTO category)
        {
            MilkResult result = new MilkResult();
            Category newCategory = new Category
            {
                CategoryName = category.CategoryName,
                Description = category.Description,
                Status = category.Status,
                ImageUrl = category.ImageUrl,
                CategoryCode = category.CategoryCode,
            };
            await _unitOfWork.GetRepository<Category>().InsertAsync(newCategory);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            if(!isSuccessful)
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
    }
}
