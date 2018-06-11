using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using AngleSharp.Dom;
using System.Text.RegularExpressions;

namespace DomModelParser.ProductGrabber
{
   public class Graber: IProductGrabber
    {
       private  IGrabStrategy strategy;
        private IStrategyResult result;

        private string shopURL;

        public Graber(string url)
        {
            this.shopURL = url;
        }

        
       public IGrabStrategy Strategy {set => strategy = value; }
        public IStrategyResult Result => result;
        public void RunGrabber()
        {
            strategy.RunScenario(this.shopURL);
            extractResult();


        }
        private void extractResult()
        {
            result = strategy.Result;
        }

        
    }
}
