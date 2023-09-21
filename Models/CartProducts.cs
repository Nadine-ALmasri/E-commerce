using E_commerce.Models.Interface;

namespace E_commerce.Models
{
    public class CartProducts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Cart? Cart { get; set; }

        public string UserId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }
    }
}
