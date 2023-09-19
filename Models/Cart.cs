namespace E_commerce.Models
{
    public class Cart
    {public int Id { get; set; }
        public string UserId { get; set; }
        public double Total { get; set; }

        public List<CartProducts> CartProducts { get; set; }
    }
}
