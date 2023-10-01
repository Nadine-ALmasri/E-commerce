using E_commerce.Models.DTOs;

namespace E_commerce.Models
{
	public class Order
	{
		
		public string Email { get; set; }
	
		public string UserName { get; set; }
		public int OrderId { get; set; }
		public CartEmail ShoppingCart { get; set; }
		public string StreetAdress { get; set; }
		public string City { get; set; }
		public DateTime OrderDate { get; set; }
		public string PostalCode { get; set; }
		public string Phone { get; set; }
		public string UserId { get; set; }
	}
}
