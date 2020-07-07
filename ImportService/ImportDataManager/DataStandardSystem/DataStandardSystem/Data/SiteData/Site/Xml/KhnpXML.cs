using DataStandardSystem.Config;
using DataStandardSystem.Data.Model;
using DataStandardSystem.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataStandardSystem.Data.Paser.Site.Xml
{
    class KhnpXML : Parser
    {
        public override String GetPaserDataList(String url)
        {
            JArray khnpXmlDataList = new JArray();
            JObject result = new JObject();

            XmlNodeList nodeList = this.GetXmlNodeURLData(url, "items");

            foreach (XmlNode node in nodeList[0])
            {
                JObject resultItem = new JObject();
                resultItem.Add("apiKey", UtilManager.GetInstance().CommonUtil.GetUniqueKey());
                resultItem.Add("apiOffer", ConfigManager.ImportType.KHNP.ToString());
                resultItem.Add("apiName", node["expl"].InnerText.Replace("\"", ""));
                resultItem.Add("doserateValue", Convert.ToDouble(node["value"].InnerText.Replace("\"", "")));
                resultItem.Add("unit", "uSv/h");
                resultItem.Add("apiOfferTime", node["time"].InnerText.Replace("\"", ""));
                resultItem.Add("dbUpdateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                khnpXmlDataList.Add(resultItem);
            }
            result.Add("dataList", khnpXmlDataList);

            return result.ToString();
        }
    }
}
