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
            /*
            IElement menuRootUL = document.GetElementsByClassName("nav")[0];
           
            var fullNav3 = menuRootUL.GetElementsByClassName("third-nav");


            foreach (var UlItem in fullNav3.Where(x=>x.ChildElementCount==2))
            {
                int menuItemsCoun = UlItem.ChildElementCount;

                for (int i = 0; i < menuItemsCoun; i++)
                {
                    var menuElement = (IHtmlListItemElement)UlItem.Children[i];
                    IElement aHrefelem = (IElement)menuElement.ChildNodes[0];
                    HTMLAnchorDetail ancdDetail = extractor.extractAchrorInfo(aHrefelem);


                    menuDTOArray.Add(new Pages.PageComponents.ShopMenu { Href = invokedPage.ShopUrl + ancdDetail.Href, ItemName = ancdDetail.Name });
                }

            }
            */


            // AngleSharp.Dom.

            /*
            var p = "dsd";
         

            IElement menuList = document.GetElementsByClassName("third-nav")[0]; //static

            int menuItemsCount = menuList.ChildElementCount;

            for (int i = 0; i < menuItemsCount; i++)
            {
                var menuElement = (IHtmlListItemElement)menuList.Children[i];
                IElement aHrefelem = (IElement)menuElement.ChildNodes[0];
                HTMLAnchorDetail ancdDetail = extractor.extractAchrorInfo(aHrefelem);


                menuDTOArray.Add(new Pages.PageComponents.ShopMenu { Href = invokedPage.ShopUrl+ancdDetail.Href, ItemName = ancdDetail.Name });
            }
            */
            menuDTOArray.Add(
                new Pages.PageComponents.ShopMenu { ItemName= "Static/15W/", Href= "http://www.wartonlogo.com/Projectors/Static/15W/" }
                );

            menuDTOArray.Add(
                new Pages.PageComponents.ShopMenu { ItemName = "Static/30W/", Href = "http://www.wartonlogo.com/Projectors/Static/30W/" }
                );

            menuDTOArray.Add(
               new Pages.PageComponents.ShopMenu { ItemName = "Rotatable/15W/", Href = "http://www.wartonlogo.com/Projectors/Rotatable/15W/" }
               );

            menuDTOArray.Add(
              new Pages.PageComponents.ShopMenu { ItemName = "Rotatable/30W/", Href = "http://www.wartonlogo.com/Projectors/Rotatable/30W/" }
              );

            menuDTOArray.Add(
            new Pages.PageComponents.ShopMenu { ItemName = "Rotatable/40W/", Href = "http://www.wartonlogo.com/Projectors/Rotatable/40W/" }
            );

            menuDTOArray.Add(
           new Pages.PageComponents.ShopMenu { ItemName = "Rotatable/60W/", Href = "http://www.wartonlogo.com/Projectors/Rotatable/60W/" }
           );
            menuDTOArray.Add(
          new Pages.PageComponents.ShopMenu { ItemName = "Rotatable/80W/", Href = "http://www.wartonlogo.com/Projectors/Rotatable/80W/" }
          );


            return menuDTOArray;


        }
        private IList<Pages.PageComponents.ShopProductsGalery> prepareGalery()
        {
            IList<Pages.PageComponents.ShopProductsGalery> galery = new List<Pages.PageComponents.ShopProductsGalery>();
            IHtmlCollection<IElement> galeryListULCollection = document.GetElementsByClassName("porjecontrs2");  //cs-product-gallery -for cnc
            if (galeryListULCollection.Count() > 0)
            {


                IElement galeryListUL = galeryListULCollection[0];
                IHtmlCollection<IElement> lICollection = galeryListUL.GetElementsByTagName("li");

                foreach (IElement liItem in lICollection)
                {
                    var extractedPageUrl=extractor.ExtractProductURL(liItem);
                    galery.Add(
                        new Pages.PageComponents.ShopProductsGalery()
                        {
                            Name = extractor.ExtractProductName(liItem),
                            ProductPageUrl = extractedPageUrl,
                            Description = extractor.ExtractProductDescription(extractedPageUrl),
                            ProductImageURL = extractor.ExtractProductImgURL(liItem),
                           



                        }

                        );






                }
            }

            return galery;
        }

        
    }
}
