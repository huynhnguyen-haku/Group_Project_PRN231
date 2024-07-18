using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.ProductCategory
{
    public class GetCategoryDTO
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string CategoryCode { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Status { get; set; } = null!;
    }

    public class CategoryDTO
    {
        public string CategoryName { get; set; } = null!;

        public string CategoryCode { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Status { get; set; } = null!;
    }
}
