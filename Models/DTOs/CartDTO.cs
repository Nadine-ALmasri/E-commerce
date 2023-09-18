namespace E_commerce.Models.DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Total { get; set; }
        public int Amount { get; set; }

    }
}
