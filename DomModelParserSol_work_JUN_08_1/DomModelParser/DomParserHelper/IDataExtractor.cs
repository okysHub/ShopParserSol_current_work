using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace DomModelParser.DomParserHelper
{
    interface IDataExtractor
    {
        string ExtractProductName(IElement el);
        string ExtractProductURL(IElement el);
        decimal ExtractProductPrice(IElement el);
        HTMLAnchorDetail extractAchrorInfo(IElement anchor);
        string ExtractProductDescription(string url);
        string ExtractProductImgURL(IElement el);


    }
}
