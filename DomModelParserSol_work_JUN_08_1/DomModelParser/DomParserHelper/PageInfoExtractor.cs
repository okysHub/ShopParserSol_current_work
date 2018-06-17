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

            var AnchWithName = el.GetElementsByTagName("a")[0];

            var brText = AnchWithName.TextContent;

            nameDefault = brText;
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
            IHtmlAnchorElement anchorElement = (IHtmlAnchorElement)el.GetElementsByTagName("a")[0];
            var url= anchorElement.PathName;
            return url;
        }
        public HTMLAnchorDetail extractAchrorInfo(IElement anchor)
        {
            return new HTMLAnchorDetail
            {
                Href = ((IHtmlAnchorElement)anchor).PathName,
                Name = ((IHtmlAnchorElement)anchor).Text,

            };
        }

        public string ExtractProductDescription(string url)
        {
            StringBuilder sb = new StringBuilder();
             HtmlParser parser = new HtmlParser();
            IHtmlDocument document;
             Webrequestor.IHTMLContentLoader graber = Webrequestor.LooderCreator.Loader;
           
            document = parser.Parse(graber.LoadContent("http://www.wartonlogo.com"+url));

          var t=  document.GetElementsByClassName("listul")[0];

            var spanElems = t.GetElementsByTagName("li");

            foreach (var spanTe in spanElems)
            {
                var ind = spanTe.InnerHtml.IndexOf("</span>");
                var len = spanTe.InnerHtml.Length;
                var clear = spanTe.InnerHtml.Substring(ind+ "</span>".Length);
                sb.Append(clear);
                sb.Append("@");
            }

            //return anchorElement.Title;
            var yuyu= sb.ToString();
            return yuyu;
        }

        public string ExtractProductImgURL(IElement el)
        {
            string defImgSrc = "";
            var imgTag = el.GetElementsByTagName("img")[0];
            defImgSrc = imgTag.GetAttribute("src");

            
            return defImgSrc;

        }
    }
}
