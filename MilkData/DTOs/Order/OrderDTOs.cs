using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MilkData.DTOs.Order.OrderDetailDTO;

namespace MilkData.DTOs.Order
{
    public class OrderDTO
    {
        public class CreateOrder
        {
            public int AccountId { get; set; }

            public string? Description { get; set; }

            public Guid VoucherCode { get; set; }

            public float TotalPrice { get; set; }

            public string Currency { get; set; } = null!;

            public string Status { get; set; } = null!;

            public string PaymentType { get; set; } = null!;

            public DateTime CreateDate { get; set; }

            public DateTime UpdateDate { get; set; }

            public string? Note { get; set; }

        }

        public class UpdateOrder
        {
            public int AccountId { get; set; }

            public string? Description { get; set; }

            public Guid VoucherCode { get; set; }

            public float TotalPrice { get; set; }

            public string Currency { get; set; } = null!;

            public string Status { get; set; } = null!;

            public string PaymentType { get; set; } = null!;

            public string? Note { get; set; }

        }

        public class GetOrder
        {
            public int OrderId { get; set; }

            public int AccountId { get; set; }

            public string? Description { get; set; }

            public Guid VoucherCode { get; set; }

            public float TotalPrice { get; set; }

            public string Currency { get; set; } = null!;

            public string Status { get; set; } = null!;

            public string PaymentType { get; set; } = null!;

            public DateTime CreateDate { get; set; }

            public DateTime UpdateDate { get; set; }

            public string? Note { get; set; }
        }

        //public class CreateOrderDTO
        //{
        //    //Order
        //    public int AccountId { get; set; }

        //    public Guid VoucherCode { get; set; }

        //    public float TotalPrice { get; set; }

        //    public string Status { get; set; } = null!;


        //    //OrderDetail
        //    public List<CreateOrderDetailDTO> OrderDetails { get; set; }
        //}

        //public class CreateOrderDetailDTO
        //{

        //    public int Quantity { get; set; }

        //    public int ProductId { get; set; }
        //}
    }
}
