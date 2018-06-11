using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.ProductGrabber
{
    public class UpdatePriceHistoryStrategy : IGrabStrategy
    {
        public IStrategyResult Result => new ProductsCollection();

        public void RunScenario(string url)
        {
            //throw new NotImplementedException();
        }
    }
}
