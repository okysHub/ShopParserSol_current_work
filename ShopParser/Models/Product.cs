using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ShopParser.Models
{
    public class Product: ModelBase
    {
        private string _name;
        private decimal _price;
        private string _description;
        private string _productPageUrl;
        private string _productImageURL;

        [Display(Name = "Name")]
        public string Name { get => _name; set => _name = value; }
        [Display(Name = "Price")]
        public decimal Price { get => _price; set => _price = value; }
        [Display(Name = "Description")]
        public string Description { get => _description; set => _description = value; }
        [Display(Name = "Product Original")]
        public string ProductPageUrl { get => _productPageUrl; set => _productPageUrl = value; }
        [Display(Name = "Picture")]
        public string ProductImageURL { get => _productImageURL; set => _productImageURL = value; }
        public ICollection<ProductPriceHistory> PriceHistory { get; set; }

        public Product()
        {
           PriceHistory = new List<ProductPriceHistory>();
            
        }
    }
}