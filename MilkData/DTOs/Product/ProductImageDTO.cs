using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Product
{
    public class ProductImageDTO
    {
        public int ImageId { get; set; }    
        public int ProductId { get; set; }
        public string Url { get; set; }
        public bool IsThumbnail { get; set; }
    }
}
