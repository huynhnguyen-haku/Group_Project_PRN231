using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Order
{
    public class PaymentDTO
    {
        public class PaymentLinkResponse
        {
            public int OrderId { get; set; }
            public string PaymentUrl { get; set; } = string.Empty;
        }

        public class PaymentOrderInfoResponse
        {
            public int ItemAmount { get; set; }
            public decimal TotalPrice { get; set; }
        }

        public class PaymentReturnResponse
        {
            public int OrderId { get; set; }
            public string? PaymentStatus { get; set; }
            public string? PaymentMessage { get; set; }
            public decimal? Amount { get; set; }
        }
    }
}
