using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public int AccountId { get; set; }

    public string Title { get; set; } = null!;

    public string BlogContent { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public string ProductSuggestUrl { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Reference { get; set; } = null!;

    public int Priority { get; set; }

    public virtual Account Account { get; set; } = null!;
}
