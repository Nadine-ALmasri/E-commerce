﻿namespace E_commerce.Models.DTOs
{
    public class UserDTO
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public CartDTO ShoppingCart { get; set; }
        public string Email{ get; set; }
        public IList<string> Roles { get; set; }
        public ICollection<Products> Products { get; internal set; }
		public ICollection<Order> orders { get; internal set; }
	}
}
