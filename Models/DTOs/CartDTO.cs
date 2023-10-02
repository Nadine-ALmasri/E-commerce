namespace E_commerce.Models.DTOs
{
    public class CartDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Total { get; set; }
        public int Amount { get; set; }

    }
    public class CartEmail
    {

		public int Id { get; set; }
		public double Total { get; set; }

        public List<CartProductDTO> CartProducts { get; set; }
    }
}
