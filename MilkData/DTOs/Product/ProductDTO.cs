using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Product
{
    public class ProductDTO
    {
        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal TotalRating { get; set; }

        public string Status { get; set; } = null!;

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
