using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.DomParserHelper
{
    class HTMLAnchorDetail
    {
        private string _href;
        private string _name;

        public string Href { get => _href; set => _href = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
