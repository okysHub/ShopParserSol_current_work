using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.ProductGrabber
{
   public class PopulateModelStrategy : IGrabStrategy
    {
        private string shopUrl;
        Pages.ShopPage mainPage;       
        ProductsCollection modeoList = new ProductsCollection();

        public IStrategyResult Result { get => modeoList;}

        public void RunScenario(string url)
        {
            this.shopUrl = url;
            Webrequestor.LooderCreator.InitLoader(Webrequestor.LoaderMode.CLEAR);
            openMAinPage();

            beginGrabModel(mainPage.PageMenu);
        }

        private void openMAinPage()
        {
            mainPage = new Pages.ShopPage(this.shopUrl);
        }

       
        private void openPage(Pages.PageComponents.ShopMenu menu)
        {
            Pages.PageComponents.IMenuNavigator navigator = menu;

            Pages.ShopProductsPage productPage = navigator.Navigate();

            collectProducts(productPage.ProductsGalery);






        }

        private void collectProducts(IList<Pages.PageComponents.ShopProductsGalery> galery)
        {
             var productModelRange = galery.Select(x=>new ProductModelDTO() { Name=x.Name, Description=x.Description, Price=x.Price, ProductImageURL=x.ProductImageURL, ProductPageUrl=x.ProductPageUrl});
             var productModelRangeListed = productModelRange.ToList();
            modeoList.AddRange(productModelRangeListed);

            
          
            
            
            /*
            foreach (Pages.PageComponents.ShopProductsGalery galeryItem in galery)
            {
                modeoList.Add
                    (
                    name: galeryItem.Name,
                    price: galeryItem.Price, 
                    description: galeryItem.Description, 
                    productPageUrl: galeryItem.ProductPageUrl,
                    productImgUrl:galeryItem.ProductImageURL
                    
                    );
                
            }
            */
            
        }
        private void beginGrabModel(IList<Pages.PageComponents.ShopMenu> menu)
        {
            foreach (Pages.PageComponents.ShopMenu menuItem in menu)
            {
                openPage(menuItem);
            }

        }
        



    }
}
