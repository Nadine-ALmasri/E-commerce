namespace E_commerce.Models.DTOs
{
    public class CartProductDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
       

       
        public ProductCategoryEmailDTO? Product { get; set; }

        public int Quantity { get; set; }
    }
}
