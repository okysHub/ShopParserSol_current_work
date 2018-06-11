using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.Webrequestor
{
    public enum LoaderMode
    {
        FULL,
        CLEAR
    }
    public static class LooderCreator
    {
        private static IHTMLContentLoader _loader;
        
        static IDictionary<string, HTMLLoaderFactory> factDict;
        static LooderCreator()
        {
            factDict = new Dictionary<string, HTMLLoaderFactory>();
            factDict.Add(Webrequestor.LoaderMode.FULL.ToString(), new RawLoaderFactory());
            factDict.Add(Webrequestor.LoaderMode.CLEAR.ToString(), new ClearLoaderFactory());
        }

        public static IHTMLContentLoader Loader { get => _loader; set => _loader = value; }

        public static IHTMLContentLoader InitLoader(LoaderMode modeEnum)
        {
            _loader= factDict[modeEnum.ToString()].Create();
            return _loader;
        }
    }
}
