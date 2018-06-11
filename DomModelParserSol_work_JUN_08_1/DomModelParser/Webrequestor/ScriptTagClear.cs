using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DomModelParser.Webrequestor
{
    class ScriptTagClear : IHTMLCleaner
    {
        public string Clear(string rawHTMLString)
        {
            Regex rRemScript = new Regex(@"<script[^>]*>[\s\S]*?</script>");
            return rRemScript.Replace(rawHTMLString, "");
        }
    }
}
