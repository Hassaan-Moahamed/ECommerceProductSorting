namespace ECommerceProductSorting.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
    }
}
