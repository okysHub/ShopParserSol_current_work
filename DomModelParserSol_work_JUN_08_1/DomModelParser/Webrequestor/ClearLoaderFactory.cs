using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.Webrequestor
{
    class ClearLoaderFactory : HTMLLoaderFactory
    {
        public override IHTMLContentLoader Create()
        {
            return new ClearedRawContentLoader();
        }
    }
}
