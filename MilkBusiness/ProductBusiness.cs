using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MilkData.DTOs.Product;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class ProductBusiness
    {
        private UnitOfWork _unitOfWork;
        public ProductBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }
        public async Task<IMilkResult> GetAllProduct()
        {
            var productList = await _unitOfWork.GetRepository<Product>()
                .GetListAsync(selector: x => new GetProductDTO
                {
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description,
                    Status = x.Status,
                    TotalRating = x.TotalRating,
                    CategoryId = x.CategoryId,
                    Quantity = x.Quantity,
                    CreateDate = x.CreateDate,
                    ImageUrl = x.ImageUrl,
                    UpdateDate = x.UpdateDate
                });
            return new MilkResult(productList);
        }

        public async Task<IMilkResult> GetProductInfo(int productId)
        {
            var product = await _unitOfWork.GetRepository<Product>()
                .SingleOrDefaultAsync(predicate: p => p.ProductId == productId,
                                    selector: x => new GetProductDTO
                                    {
                                        ProductId = x.ProductId,
                                        Name = x.Name,
                                        Price = x.Price,
                                        Description = x.Description,
                                        Status = x.Status,
                                        TotalRating = x.TotalRating,
                                        CategoryId = x.CategoryId,
                                        Quantity = x.Quantity,
                                        CreateDate = x.CreateDate,
                                        ImageUrl = x.ImageUrl,
                                        UpdateDate = x.UpdateDate
                                    });
            return new MilkResult(product);
        }

        public async Task<IMilkResult> CreateProduct(ProductDTO product)
        {
            MilkResult result = new MilkResult();

            // Validate price (ensure non-negative)
            if (product.Price < 0)
            {
                return new MilkResult(-2, "Price cannot be negative");
            }

            if (product.Quantity < 0)
            {
                return new MilkResult(-3, "Quantity cannot be negative");
            }

            Product newProduct = new Product()
            {
                CategoryId = product.CategoryId,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Status = product.Quantity > 0 ? "InStock" : "OutOfStock", // Assuming valid string values
                TotalRating = 0,
                CreateDate = DateTime.Now,
                UpdateDate= DateTime.Now,
                ImageUrl = product.ImageUrl,
                Quantity = product.Quantity,
            };

            await _unitOfWork.GetRepository<Product>().InsertAsync(newProduct);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            if (!isSuccessful)
            {
                result.Status = -1;
                result.Message = "Create product failed";
            }
            else
            {
                result = new MilkResult(1, "Create successfully");
            }

            return result;
        }

        public async Task<IMilkResult> UpdateProductInfo(int id, ProductDTO productInfo)
        {
            Product currentProduct = await _unitOfWork.GetRepository<Product>()
                .SingleOrDefaultAsync(predicate: p => p.ProductId == id);

            if (currentProduct == null)
            {
                return new MilkResult(-1, "Product not found");
            }
            else
            {
                // Validate price (ensure non-negative)
                if (productInfo.Price < 0)
                {
                    return new MilkResult(-2, "Price cannot be negative");
                }

                currentProduct.CategoryId = productInfo.CategoryId;
                currentProduct.Name = String.IsNullOrEmpty(productInfo.Name) ? currentProduct.Name : productInfo.Name;
                currentProduct.Price = productInfo.Price;

                // Update quantity and status (handle out-of-stock)
                currentProduct.Quantity = productInfo.Quantity;
                currentProduct.Status = productInfo.Quantity > 0 ? "InStock" : "OutOfStock";

                currentProduct.Description = String.IsNullOrEmpty(productInfo.Description) ? currentProduct.Description : productInfo.Description;
                currentProduct.UpdateDate = DateTime.Now;

                currentProduct.Description = String.IsNullOrEmpty(productInfo?.Description) ? currentProduct.Description : productInfo.Description;
                currentProduct.ImageUrl = String.IsNullOrEmpty(productInfo?.ImageUrl) ? currentProduct.ImageUrl : productInfo.ImageUrl;


                _unitOfWork.GetRepository<Product>().UpdateAsync(currentProduct);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(productInfo);
        }

        public async Task<IMilkResult> DeleteProduct(int productId)
        {
            Product product = await _unitOfWork.GetRepository<Product>()
                .SingleOrDefaultAsync(predicate: p => p.ProductId == productId);
            if (product == null) return new MilkResult();
            else
            {
                product.Status = "Deleted";
                _unitOfWork.GetRepository<Product>().UpdateAsync(product);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult(1, "Delete successfully");
        }
    }
}
