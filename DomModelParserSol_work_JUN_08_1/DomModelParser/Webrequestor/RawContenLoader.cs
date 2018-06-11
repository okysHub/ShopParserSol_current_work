using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace DomModelParser.Webrequestor
{
    class RawContenLoader : IHTMLContentLoader
    {
        private string urlToGo;

        private WebRequest request;
        private WebResponse response;
        private StreamReader reader;
        private Stream streamReceiver;
        protected string htmlText;


        public virtual string LoadContent(string urlstring)
        {
            this.urlToGo = urlstring;
            requestFromWeb();
            closeConnection();
           return setData();
        }
        private void requestFromWeb()
        {
            request = WebRequest.Create(urlToGo);
            response = request.GetResponse();
            streamReceiver = response.GetResponseStream();
            reader = new StreamReader(streamReceiver);
            htmlText = reader.ReadToEnd();
        }
        private void closeConnection()
        {
            response.Close();
            reader.Close();
            streamReceiver.Close();
        }
        protected virtual string setData()
        {
            return htmlText;
        }
    }

}

