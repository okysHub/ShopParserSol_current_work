using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser
{
    class Program
    {
        static void Main(string[] args)
        {

           
            ProductGrabber.IProductGrabber graber = new ProductGrabber.Graber("https://cnc.prom.ua");
            graber.Strategy = new ProductGrabber.PopulateModelStrategy();
            graber.RunGrabber();
            ProductGrabber.ProductsCollection result= (ProductGrabber.ProductsCollection)graber.Result;


            Webrequestor.LooderCreator.InitLoader(Webrequestor.LoaderMode.CLEAR);

            Pages.ShopPage mainPage = new Pages.ShopPage("https://cnc.prom.ua");

            Pages.ShopProductsPage productPage= ((Pages.PageComponents.IMenuNavigator)mainPage.PageMenu[0]).Navigate();
             productPage = ((Pages.PageComponents.IMenuNavigator)mainPage.PageMenu[2]).Navigate();


            /*
            Webrequestor.LooderCreator.InitLoader(Webrequestor.LoaderMode.CLEAR);
          Pages.ShopPage mainPage = new Pages.ShopPage("https://cnc.prom.ua");
           

            ProductGrabber.ShopMenu itemR = mainPage.PageMenu[0];

            ProductGrabber.IMenuNavigator navigator = (ProductGrabber.IMenuNavigator)mainPage.PageMenu[2];
            Pages.ShopProductsPage productPage = navigator.Navigate();

            ((ProductGrabber.IMenuNavigator)itemR).Navigate();
         
     ;
            ProductGrabber.IMenuNavigator pageNavi = mainPage.PageMenu[0];
            pageNavi.Navigate();
          
           
            

             

            ProductGrabber.Graber graber = new ProductGrabber.Graber(shopUrl: "https://cnc.prom.ua", productLimit: 100);
            
            
            graber.ProvideProductsList();*/






        }
    }
}
