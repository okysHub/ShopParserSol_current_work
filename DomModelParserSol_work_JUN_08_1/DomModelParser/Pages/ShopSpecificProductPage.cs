using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomModelParser.Pages.PageComponents;

namespace DomModelParser.Pages
{
    class ShopSpecificProductPage : Page
    {
        DomParserHelper.IDomElementsProvider domDataProvider = null;
        private PageComponents.ShopProductComponent _productItem;
        internal ShopProductComponent ProductItem { get => _productItem; set => _productItem = value; }
        public ShopSpecificProductPage(string url) : base(url)
        {
            domDataProvider = new DomParserHelper.DomProvider(base.document, this);
            this._productItem = this.domDataProvider.ProvideProductItem();

        }

        
    }
}
