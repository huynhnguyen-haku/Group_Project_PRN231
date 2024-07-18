using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Order
{
    public class OrderDetailDTO
    {
        public class GetOrderDetail
        {
            public int OrderDetailId { get; set; }

            public int Quantity { get; set; }

            public int ProductId { get; set; }

            public int OrderId { get; set; }
        }

        public class CreateOrderDetail
        {
            public int OrderId { get; set; }

            public int Quantity { get; set; }

            public int ProductId { get; set; }
        }

        public class UpdateOrderDetail
        {
            public int OrderId { get; set; }

            public int Quantity { get; set; }

            public int ProductId { get; set; }
        }

        public class OrderDetailsInput
        {
            public int OrderId { get; set; }
            public List<CreateOrderDetail> OrderDetails { get; set; }
        }
    }
}
