﻿using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models.DTOs
{
    public class UserEmailDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public CartEmail ShoppingCart { get; set; }
        public  string StreetAdress { get; set; }
		public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
    }
}