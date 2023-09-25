namespace E_commerce.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }

    public class ProductCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string categoryname { get; set; }
        public string ImageUrl { get; set; }
    }
    public class ProductCategoryEmailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
       
    }

}
