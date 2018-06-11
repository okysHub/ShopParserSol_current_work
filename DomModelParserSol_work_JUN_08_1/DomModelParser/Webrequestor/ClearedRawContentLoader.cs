using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.Webrequestor
{
    class ClearedRawContentLoader: RawContenLoader
    {
        private IHTMLCleaner cleanHTML = new ScriptTagClear();
        protected override string setData()
        {
          return  this.htmlText=cleanHTML.Clear(this.htmlText);           
        }
    }
}
