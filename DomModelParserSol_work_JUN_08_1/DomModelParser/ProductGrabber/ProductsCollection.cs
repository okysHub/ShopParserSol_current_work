using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.ProductGrabber
{
    public class ProductsCollection: IStrategyResult
    {
        private IList<ProductModelDTO> productModel = new List<ProductModelDTO>();

        public IList<ProductModelDTO> Items { get => productModel; set => productModel = value; }

        public void Add(string name, decimal price, string description, string productPageUrl, string productImgUrl)
        {
            
            productModel.Add(new ProductModelDTO { Name = name, Price = price, Description = description, ProductPageUrl = productPageUrl, ProductImageURL=productImgUrl });
        }

        internal void AddRange(IList<ProductModelDTO> range)
        {
            ((List<ProductModelDTO>)productModel).AddRange(range);
        }

       
    }
}
