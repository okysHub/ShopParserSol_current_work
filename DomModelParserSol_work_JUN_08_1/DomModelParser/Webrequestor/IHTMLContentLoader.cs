using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace DomModelParser.Webrequestor
{
   public interface IHTMLContentLoader
    {
        string LoadContent(string urlstring);
    }
}
