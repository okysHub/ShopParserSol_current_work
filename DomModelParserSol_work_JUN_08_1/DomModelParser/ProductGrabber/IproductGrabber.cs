using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomModelParser.ProductGrabber
{
  public  interface IProductGrabber
    {
        void RunGrabber();
        IStrategyResult Result { get;  }
        IGrabStrategy Strategy { set; }



    }
}
