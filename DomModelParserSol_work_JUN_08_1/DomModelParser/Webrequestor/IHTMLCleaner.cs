using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.Webrequestor
{
    interface IHTMLCleaner
    {
        string Clear(string rawHTMLString);
    }
}
