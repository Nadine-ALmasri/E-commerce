namespace E_commerce.Models
{
    public class Cart
    {
        public  string Id { get; set; }
        public string UserId { get; set; }
        public double Total { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; }

    }
}
