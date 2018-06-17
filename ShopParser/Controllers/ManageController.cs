using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomModelParser.ProductGrabber;

namespace ShopParser.Controllers
{
    public class ManageController : Controller
    {
        IProductGrabber graber;
        Models.ProductContext db;
        IList<Models.Product> productModel;

        static int graberState = 0;
       

        // GET: Manage
        public ActionResult Index()
        {
           // UIRules.GraberMode mode = new UIRules.GraberMode();
            db = new Models.ProductContext();
            var productCount = db.Products.Count();
            if (productCount == 0)
            {
                /*
                mode.Action = "RunGraber";
                mode.Description = "Get products";
                */

                ViewBag.SelectPV = "ModePopultaePV";

            }
            else
            {
                ViewBag.SelectPV = "ModeUpdatePV";
                /*
                mode.Action = "UpdatePrice";
                mode.Description = "Update prices";
                */


            }
           return View();
        }

        public ActionResult RunGraber()
        {
            if (graberState == 1)
            {
                return PartialView("GraberWorkingMessage");
            }
            graberState = 1;



            db = new Models.ProductContext();
            graber = new Graber("http://www.wartonlogo.com"); //https://cnc.prom.ua
            productModel = new List<Models.Product>();


            graber.Strategy = new PopulateModelStrategy();
            
            graber.RunGrabber();
            

            ProductsCollection result = (ProductsCollection)graber.Result;

            InsertNewResult(result);


            ViewBag.Count = productModel.Count;
            graberState = 0;
            return PartialView("RunGraberResult");

        }
        public object UpdatePrice()
        {
            db = new Models.ProductContext();
            graber = new Graber("https://cnc.prom.ua");
            graber.Strategy = new PopulateModelStrategy();
            graber.RunGrabber();
            ProductsCollection result = (ProductsCollection)graber.Result;
            UpdatePriceHistory(result);

            

            return new { s = "Updated"};
        }

       
        private void InsertNewResult(ProductsCollection graberResult)
        {
            var data = graberResult.Items;

            foreach (var dataItem in data)
            {
                ICollection<Models.ProductPriceHistory> priceHistory = new List<Models.ProductPriceHistory>();
                priceHistory.Add(new Models.ProductPriceHistory() { Price = dataItem.Price, UpdateDate = DateTime.Now });
                productModel.Add(new Models.Product()
                {
                    Name = dataItem.Name,
                    Description = dataItem.Description,
                    Price = dataItem.Price,
                    ProductImageURL = "http://www.wartonlogo.com"+dataItem.ProductImageURL,
                    ProductPageUrl = "http://www.wartonlogo.com" + dataItem.ProductPageUrl,
                    PriceHistory = priceHistory,
                    MenuUrl=dataItem.MenuLink

                });






            }

            db.Products.AddRange(productModel);
            db.SaveChanges();

        }

        
        private void UpdatePriceHistory(ProductsCollection graberResult)
        {
            var data = graberResult.Items;

            foreach (ProductModelDTO newdataItem in data)
            {
                var productToUpdate = db.Products.Where(p => p.ProductPageUrl == newdataItem.ProductPageUrl).FirstOrDefault();
                productToUpdate.Price = newdataItem.Price;


                var productItemId = db.Products.Where(p => p.ProductPageUrl == newdataItem.ProductPageUrl).Select(p => p.Id).FirstOrDefault();

                db.PriceHistory.Add(new Models.ProductPriceHistory {Price=newdataItem.Price, ProductId= productItemId, UpdateDate= DateTime.Now });
                db.SaveChanges();
            }

           
        }

        public ActionResult ClearDb()
        {
            db = new Models.ProductContext();
            db.Database.ExecuteSqlCommand("delete from ProductPriceHistories;delete from Products;");

            return PartialView("ClearBasePV");
        }
    }
}