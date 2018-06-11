using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace DomModelParser.Pages
{
    internal class ShopPage: Page
    {


        DomParserHelper.IDomElementsProvider domDataProvider = null;
        private IList<PageComponents.ShopMenu> pageMenu = null;

        public ShopPage(string url) : base(url)
        {
            domDataProvider = new DomParserHelper.DomProvider(base.document,this);
            this.pageMenu = domDataProvider.ProvideMenu();
       
        }

        

        public IList<PageComponents.ShopMenu> PageMenu { get => pageMenu;  }

       



    }
}
