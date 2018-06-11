using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using DomModelParser.Pages.PageComponents;

namespace DomModelParser.Pages
{
    class ShopProductsPage : Page
    {
        DomParserHelper.IDomElementsProvider domDataProvider = null;
        private IList<PageComponents.ShopProductsGalery> productsGalery;
        public IList<ShopProductsGalery> ProductsGalery { get => productsGalery; set => productsGalery = value; }
        public ShopProductsPage(string url) : base(url)
        {
            domDataProvider = new DomParserHelper.DomProvider(base.document, this);
            this.productsGalery = this.domDataProvider.ProvideProducGalery();

        }

        
    }
}
