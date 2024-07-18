namespace MilkWebApp.Models.Product
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal TotalRating { get; set; }

        public string Status { get; set; } = null!;

        public string HttpMethod { get; set; }
    }
}
