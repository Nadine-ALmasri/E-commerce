namespace E_commerce.Models
{
    public class Product
    {
        internal string imageUrl;

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        //Navigation properties
        public Category Category { get; set; }
        public ICollection<CartProduct>? CartProducts { get; set; }


    }
}
