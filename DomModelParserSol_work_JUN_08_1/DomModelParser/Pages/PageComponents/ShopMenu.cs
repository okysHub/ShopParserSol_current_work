using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.Pages.PageComponents
{
    class ShopMenu: IMenuNavigator
    {
        private string _href;
        private string _itemName;

       
        public string ItemName { get => _itemName; set => _itemName = value; }
        public string Href { get => _href; set => _href = value; }

        ShopProductsPage IMenuNavigator.Navigate()
        {
            return new ShopProductsPage(_href);
        }
    }
}
