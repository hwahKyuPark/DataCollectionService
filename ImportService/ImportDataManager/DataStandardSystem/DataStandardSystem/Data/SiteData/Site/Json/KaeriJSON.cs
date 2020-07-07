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

namespace DataStandardSystem.Data.Paser.Site.Json
{
    public class KaeriJSON : Parser
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        public override String GetPaserDataList (String url)
        {
            JArray kaeriJsonList = new JArray();
            JObject result = new JObject();

            // String -> jSonArray
            String strSiteData = this.GetJsonURLData(url);
            JArray jsonArraySiteData = JArray.Parse(strSiteData);

            foreach (JObject jsonItem in jsonArraySiteData[0])
            {
                JObject resultItem = new JObject();
                resultItem.Add("apiKey", UtilManager.GetInstance().CommonUtil.GetUniqueKey());
                resultItem.Add("apiOffer", ConfigManager.ImportType.KAERI.ToString());
                resultItem.Add("apiName", jsonItem["NAME"].ToString().Replace("\"", ""));
                resultItem.Add("doserateValue", Convert.ToDouble(jsonItem["ERM"].ToString().Replace("\"", "")));
                resultItem.Add("unit", "uSv/h");
                resultItem.Add("apiOfferTime", jsonItem["TIME"].ToString().Replace("\"", ""));
                resultItem.Add("dbUpdateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                kaeriJsonList.Add(resultItem);
            }
            result.Add("dataList", kaeriJsonList);

            return result.ToString();
        }
    }
}
