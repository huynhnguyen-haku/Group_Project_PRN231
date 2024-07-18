namespace MilkWebApp.Models.Blog
{
    public class BlogModel
    {
        public int BlogId { get; set; } 

        public int AccountId { get; set; }

        public string Title { get; set; } = null!;

        public string BlogContent { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string ProductSuggestUrl { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string Reference { get; set; } = null!;

        public int Priority { get; set; }

        public string HttpMethod { get; set; }
    }
}
