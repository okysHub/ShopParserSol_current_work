using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DomModelParser.ProductGrabber;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.IO;

namespace ShopParser.Controllers
{
    public class HomeController : Controller
    {

        

        Models.ProductContext db = new Models.ProductContext();
      


        public ActionResult Index()
        {/*
            ExcelPackage excel = new ExcelPackage();

            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

            var data = db.Products;
            workSheet.Cells[1, 1].LoadFromCollection(data, true);

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Contact.xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
            */


            ViewBag.ProdCount = db.Products.Count();

            return View(db.Products);
        }

        public ActionResult Tran()
        {
            
             


          

            return View(db.Products.FirstOrDefault());
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