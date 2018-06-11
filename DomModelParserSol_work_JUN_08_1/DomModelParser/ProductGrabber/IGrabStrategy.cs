using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.ProductGrabber
{
    public interface IGrabStrategy
    {
        void RunScenario(string url);
        IStrategyResult Result { get; }

    }
}
