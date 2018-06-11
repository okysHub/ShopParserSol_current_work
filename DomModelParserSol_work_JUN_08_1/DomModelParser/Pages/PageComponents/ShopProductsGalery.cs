using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.Pages.PageComponents
{
    class ShopProductsGalery
    {
        private string _name;
        private decimal _price;
        private string _description;
        private string _productPageUrl;
        private string _productImageURL;

        public string Name { get => _name; set => _name = value; }
        public decimal Price { get => _price; set => _price = value; }
        public string Description { get => _description; set => _description = value; }
        public string ProductPageUrl { get => _productPageUrl; set => _productPageUrl = value; }
        public string ProductImageURL { get => _productImageURL; set => _productImageURL = value; }
    }
}
