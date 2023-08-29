﻿namespace E_commerce.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //Navigation properties
        public List<Product> Products { get; set; }

    }
}
