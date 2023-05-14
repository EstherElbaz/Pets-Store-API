namespace DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public int ProductCategoryId { get; set; }
        public string ProductColor { get; set; } = null!;
        public int ProductPrice { get; set; }
        public string ProductImageUrl { get; set; } = null!;
    }
}