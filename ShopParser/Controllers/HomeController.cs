using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DomModelParser.ProductGrabber;
using Newtonsoft.Json;

namespace ShopParser.Controllers
{
    public class HomeController : Controller
    {

        

        Models.ProductContext db = new Models.ProductContext();
      


        public ActionResult Index()
        {

            ViewBag.ProdCount = db.Products.Count();

            return View(db.Products);
        }
        public ActionResult Details(int? id)
        {
            

          
            if (id==null)
            {
             return  PartialView("EmptyDetailParamError");
            }
            
          
            var t = db.Products.Where(p => p.Id == id).Include(h => h.PriceHistory).ToList();
            if (t.Count == 0)
            {
                return PartialView("EmptyDetailParamError");
            }
            return View(t.FirstOrDefault());
        }

        

        public ContentResult JsonOutput()
        {
            

          
            var data = db.Products.Include((x) => x.PriceHistory);

            var list = JsonConvert.SerializeObject(data,Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });


            return Content(list, "application/json");
        }

        



    }
}