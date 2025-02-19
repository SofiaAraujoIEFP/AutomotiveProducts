﻿using AutomotiveProducts.Entities;

namespace IAutomotiveProductsApi.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCompleted { get; set; }
        public decimal SalePrice { get; set; }
        public string Supplier {  get; set; }
        public int SupplierRef { get; set; }
        public long Quantity { get; set; }
        //public List<string> ImageUrl { get; set; }
    }

    public class Products
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
    }
}
