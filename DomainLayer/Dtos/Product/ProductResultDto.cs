namespace DomainLayer.Dtos.Product
{
    public class ProductResultDto : BaseResultDto
    {
        public Guid? ProductCategoryId { get; set; }
        public string? ProductCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
    }
}
