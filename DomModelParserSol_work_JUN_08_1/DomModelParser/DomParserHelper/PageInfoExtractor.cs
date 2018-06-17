using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using AngleSharp.Dom;
using System.Text.RegularExpressions;

namespace DomModelParser.DomParserHelper
{
    class PageInfoExtractor : IDataExtractor
    {
        public string ExtractProductName(IElement el)
        {
            string nameDefault = "NA";
            var spanwithName = el.GetElementsByClassName("cs-product-gallery__sku cs-goods-sku");
            foreach (var spanItem in spanwithName)
            {
                nameDefault = spanItem.TextContent;
            }
            return nameDefault;
        }

        public decimal ExtractProductPrice(IElement el)
        {
            IElement spanElement = el.GetElementsByClassName("cs-goods-price__value")[0];

            string priceStrNonWs = Regex.Replace(spanElement.TextContent, @"\s+", "");
           
            Regex expr = new Regex(@"[^\d]");
            MatchCollection matche = expr.Matches(priceStrNonWs);
            int secodStrPosition = matche[1].Index;

           string clearedString= spanElement.TextContent.Substring(0, secodStrPosition);


            return decimal.Parse(clearedString);
        }

        public string ExtractProductURL(IElement el)
        {
            IHtmlAnchorElement anchorElement = (IHtmlAnchorElement)el.GetElementsByClassName("cs-product-gallery__image-link")[0];
            return anchorElement.Href;
        }
        public HTMLAnchorDetail extractAchrorInfo(IElement anchor)
        {
            return new HTMLAnchorDetail
            {
                Href = ((IHtmlAnchorElement)anchor).PathName,
                Name = ((IHtmlAnchorElement)anchor).Text,

            };
        }

        public string ExtractProductDescription(IElement el)
        {
            IHtmlAnchorElement anchorElement = (IHtmlAnchorElement)el.GetElementsByClassName("cs-product-gallery__image-link")[0];

            return anchorElement.Title;
        }

        public string ExtractProductImgURL(IElement el)
        {
            string defImgSrc = "";
             var anchor= el.GetElementsByClassName("cs-product-gallery__image-link")[0];
            var anchChilds = anchor.ChildNodes[0];

            var img1 = anchor.GetElementsByClassName("cs-product-gallery__image img-ondemand");
            var img2 = anchor.GetElementsByClassName("cs-product-gallery__image");

            if (img1.Length > 0)
            {
             return   defImgSrc = ((IHtmlImageElement)img1[0]).GetAttribute("longdesc");
            }
            if (img2.Length > 0)
            {
              return  defImgSrc = ((IHtmlImageElement)img2[0]).Source;
            }

            // var img = anchor.GetElementsByClassName("cs - product - gallery__image");

            /*  var srcToCheck = ((IHtmlImageElement)anchChilds).Source;

              if (srcToCheck == "https://static-cache.ua.uaprom.net/image/empty.gif?r=1155d595e2b807e59a7982523d601952")
              {
                  Console.WriteLine("dsds");
              }
              */
            //return ((IHtmlImageElement)anchChilds).Source;
            //            return ((IHtmlImageElement)img).Source;
            if (defImgSrc == "https://static-cache.ua.uaprom.net/image/empty.gif?r=1155d595e2b807e59a7982523d601952")
            {
                Console.WriteLine("dsds");
            }  
            return defImgSrc;

        }
    }
}
