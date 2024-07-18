using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Order
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

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
