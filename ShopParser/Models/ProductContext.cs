using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace ShopParser.Models
{
    public class ProductContext:DbContext
    {
        public ProductContext() : base("DbConnection")
        { }

        public DbSet<Product> Products  { get; set; }
        public DbSet<ProductPriceHistory> PriceHistory { get; set; }
    }
}