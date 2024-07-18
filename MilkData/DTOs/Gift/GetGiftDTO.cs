using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Gift
{
    public class GetGiftDTO
    {
        public int GiftId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Point { get; set; }

        public int Quantity { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Status { get; set; } = null!;
    }

    public class GiftDTO
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public int Point { get; set; }

        public int Quantity { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Status { get; set; } = null!;
    }
}
