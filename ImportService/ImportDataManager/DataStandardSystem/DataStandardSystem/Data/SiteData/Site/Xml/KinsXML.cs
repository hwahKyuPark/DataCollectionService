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

namespace DataStandardSystem.Data.Paser.Site.Json
{
    class KinsXML : Parser
    {

        public override String GetPaserDataList(String url)
        {
            JArray kinsXmlDataList = new JArray();
            JObject result = new JObject();
       
            XmlNodeList nodeList = this.GetXmlNodeURLData(url, "DocumentElement");

            foreach (XmlNode node in nodeList[0])
            {
                JObject resultItem = new JObject();
                resultItem.Add("apiKey", UtilManager.GetInstance().CommonUtil.GetUniqueKey());
                resultItem.Add("apiOffer", ConfigManager.ImportType.KINS.ToString());
                resultItem.Add("apiName", node["name"].InnerText.Replace("\"", ""));
                resultItem.Add("doserateValue", Convert.ToDouble(node["erm"].InnerText.Replace("\"", "")));
                resultItem.Add("unit", "uSv/h");
                resultItem.Add("apiOfferTime", node["time"].InnerText.Replace("\"", ""));
                resultItem.Add("dbUpdateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                kinsXmlDataList.Add(resultItem);
            }
            result.Add("dataList", kinsXmlDataList);

            return result.ToString();
        }
    }
}
