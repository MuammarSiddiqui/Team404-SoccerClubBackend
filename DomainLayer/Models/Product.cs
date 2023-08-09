
namespace DomainLayer.Models
{
    public class Product : BaseModal
    {
        public Guid? ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public List<MatchStats> MatchStats { get; set; } = new List<MatchStats>();
    }

}
