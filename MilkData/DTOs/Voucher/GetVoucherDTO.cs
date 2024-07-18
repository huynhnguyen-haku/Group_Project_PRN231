using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Voucher
{
    public class GetVoucherDTO
    {
        public Guid VoucherId { get; set; }

        public int Value { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Type { get; set; } = null!;

        public string? Description { get; set; }

        public string Status { get; set; } = null!;
    }

    public class VoucherDTO
    {
        public int Value { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Type { get; set; } = null!;

        public string? Description { get; set; }

        public string Status { get; set; } = null!;
    }
}
