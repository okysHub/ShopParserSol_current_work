using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace DomModelParser.Pages
{
    abstract class Page
    {
        Webrequestor.IHTMLContentLoader graber;
       protected HtmlParser parser = new HtmlParser();
       protected IHtmlDocument document;
        protected string htmlContext;
       private string shopUrl;

        public string ShopUrl { get => shopUrl; }

        public Page(string url)
        {
            this.shopUrl = url;
            graber = Webrequestor.LooderCreator.Loader;
            htmlContext = graber.LoadContent(url);
            document = parser.Parse(htmlContext);
            
        }
    }
}
