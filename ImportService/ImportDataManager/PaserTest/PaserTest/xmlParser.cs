using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PaserTest
{
    class xmlParser
    {

        public void XmlParsorTest(){
            XmlDocument xml = new XmlDocument();
      
            // 한수원
            //string url = "http://www.khnp.co.kr/environ/service/realtime/radiorate?serviceKey=Aui8iRSVUDkQXilePOlm3ohlfZT0lUrdLG4M5Sly7gAAUlgMWL6MuidTSUeX4M%2FvBXW0OLBnwyXbz%2FHdJvViHQ%3D%3D&genName=YK";
         
            //kins
            String url = "http://59.24.28.107:9090/OpenApiKins/xmlData?UID=admin&AKEY=3e5cbb06e275471194acddd5d16560fe";
            //String url = "http://iernet.kins.re.kr/IERNet.asmx/xmlData?UID=gwangju&AKEY=rEromH4R36qJm5JLYYTuZHwakTzMKx";
            xml.Load(url);


            XmlNodeList xnList = xml.GetElementsByTagName("DocumentElement");
            //XmlNodeList xnList = xml.GetElementsByTagName("items");
            //XmlNodeList xnList = xml.SelectNodes("/response/body/items/item");
            //XmlNodeList xnList = xml.SelectNodes("/DataTable/diffgr/DocumentElement");

            foreach (XmlNode node in xnList[0])
            {
                Console.WriteLine(":::" + node["name"].InnerText + "::" + node["unit"].InnerText + ":::");
            }
        }
    }
}
