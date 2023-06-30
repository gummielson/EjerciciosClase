namespace Domain.Entities
{
    public class ProductEntity
    {
        public string Title { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public float Rate { get; set; }
        public int Count { get; set; }
    }
}
