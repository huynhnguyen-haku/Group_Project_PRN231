using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class FeedbackMedia
{
    public int FeedbackMediaId { get; set; }

    public int FeedbackId { get; set; }

    public string MediaUrl { get; set; } = null!;

    public string MediaType { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public virtual Feedback Feedback { get; set; } = null!;
}
