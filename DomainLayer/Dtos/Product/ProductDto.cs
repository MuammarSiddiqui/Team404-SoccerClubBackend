
using Microsoft.AspNetCore.Http;

namespace DomainLayer.Dtos.Product
{
    public class ProductDto
    {
        public Guid? Id { get; set; }
        public Guid? ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public int StockQuantity { get; set; }
    }
}
