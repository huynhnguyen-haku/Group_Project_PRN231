using System;
using System.Collections.Generic;

namespace MilkWebApp.Models.Order;

public partial class OrderModel
{
    public int OrderId { get; set; }

    public int AccountId { get; set; }

    public string? Description { get; set; }

    public Guid VoucherCode { get; set; }

    public float TotalPrice { get; set; }

    public string Currency { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string PaymentType { get; set; } = null!;

    public string? Note { get; set; }

    public string HttpMethod { get; set; }
}
