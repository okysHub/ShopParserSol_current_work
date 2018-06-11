using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.DomParserHelper
{
    interface IDomElementsProvider
    {
       IList<Pages.PageComponents.ShopMenu> ProvideMenu();
       IList<Pages.PageComponents.ShopProductsGalery> ProvideProducGalery();
       Pages.PageComponents.ShopProductComponent ProvideProductItem();
    }
}
