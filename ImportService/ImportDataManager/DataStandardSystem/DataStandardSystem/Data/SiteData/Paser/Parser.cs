using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataStandardSystem.Data.Paser
{
    public abstract class Parser
    {
        public abstract String GetPaserDataList(String url);

        public XmlNodeList GetXmlNodeURLData(String url, String tagName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(url);

            XmlNodeList xmlNodeList = xml.GetElementsByTagName(tagName);

            return xmlNodeList;
        }

        public String GetJsonURLData(String url)
        {
            String strJsonURLData = "";

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    webClient.Encoding = Encoding.UTF8;
                    strJsonURLData = webClient.DownloadString(url);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return strJsonURLData;
        }

    }
}
