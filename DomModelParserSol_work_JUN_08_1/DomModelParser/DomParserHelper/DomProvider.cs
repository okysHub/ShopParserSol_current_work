using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace DomModelParser.DomParserHelper
{
    class DomProvider : IDomElementsProvider
    {
        private IHtmlDocument document = null;
        private IDataExtractor extractor = null;
        private Pages.Page invokedPage = null;

        public DomProvider(IHtmlDocument documentDom, Pages.Page invokedPageLink)
        {
            this.document = documentDom;
            this.invokedPage = invokedPageLink;
            extractor = new PageInfoExtractor();
        }
        public IList<Pages.PageComponents.ShopMenu> ProvideMenu()
        {
          return  prepareMenu();

        }

        public IList<Pages.PageComponents.ShopProductsGalery> ProvideProducGalery()
        {
            return prepareGalery();
        }

       public  Pages.PageComponents.ShopProductComponent ProvideProductItem()
        {
            return prepareProductInfo();
        }

        private Pages.PageComponents.ShopProductComponent prepareProductInfo()
        {
            return new Pages.PageComponents.ShopProductComponent();
        }

        private IList<Pages.PageComponents.ShopMenu> prepareMenu()
        {
            IList<Pages.PageComponents.ShopMenu> menuDTOArray = new List<Pages.PageComponents.ShopMenu>();

          
            IElement menuList = document.GetElementsByClassName("cs-nav")[0];

            int menuItemsCount = menuList.ChildElementCount;

            for (int i = 1; i < menuItemsCount; i++)
            {
                IElement menuElement = (IElement)menuList.ChildNodes[i];
                IElement aHrefelem = (IElement)menuElement.ChildNodes[0];
                HTMLAnchorDetail ancdDetail = extractor.extractAchrorInfo(aHrefelem);


                menuDTOArray.Add(new Pages.PageComponents.ShopMenu { Href = invokedPage.ShopUrl+ancdDetail.Href, ItemName = ancdDetail.Name });
            }

            menuDTOArray.Add(
          new Pages.PageComponents.ShopMenu { ItemName = "Auto", Href = "http://www.wartonlogo.com/Projectors/Gobos%20Auto-switch/" }
          );
            


            return menuDTOArray;


        }
        private IList<Pages.PageComponents.ShopProductsGalery> prepareGalery()
        {
            IList<Pages.PageComponents.ShopProductsGalery> galery = new List<Pages.PageComponents.ShopProductsGalery>();
            IHtmlCollection<IElement> galeryListULCollection = document.GetElementsByClassName("cs-product-gallery");
            if (galeryListULCollection.Count() > 0)
            {


                IElement galeryListUL = galeryListULCollection[0];
                IHtmlCollection<IElement> lICollection = galeryListUL.GetElementsByTagName("li");

                foreach (IElement liItem in lICollection)
                {
                    galery.Add(
                        new Pages.PageComponents.ShopProductsGalery()
                        {
                            Name = extractor.ExtractProductName(liItem),
                            ProductPageUrl = extractor.ExtractProductURL(liItem),
                            Price = extractor.ExtractProductPrice(liItem),
                            Description = extractor.ExtractProductDescription(liItem),
                            ProductImageURL = extractor.ExtractProductImgURL(liItem)


                        }

                        );






                }
            }

            return galery;
        }

        
    }
}
