using DataStandardSystem.Config;
using DataStandardSystem.Data.Model;
using DataStandardSystem.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataStandardSystem.Data.Paser.Site.Json
{
    public class UramonJSON : Parser
    {
        public override String GetPaserDataList(string url)
        {
            JArray uramonJsonList = new JArray();
            JObject result = new JObject();

            // String -> Json
            String strSidteData = this.GetJsonURLData(url);
            JObject convertJsonSiteData = JObject.Parse(strSidteData);
            
            foreach(JObject jsonItem in convertJsonSiteData["openApiExportDeviceList"])
            {
                JObject resultItem = new JObject();
                resultItem.Add("apiKey", UtilManager.GetInstance().CommonUtil.GetUniqueKey());
                resultItem.Add("apiOffer", ConfigManager.ImportType.URAMON.ToString());
                resultItem.Add("apiName", jsonItem["name"].ToString().Replace("\"", ""));
                resultItem.Add("doserateValue", Convert.ToDouble(jsonItem["doserate"].ToString().Replace("\"", "")));
                resultItem.Add("unit", jsonItem["unit"].ToString().Replace("\"", ""));
                resultItem.Add("apiOfferTime", jsonItem["time"].ToString().Replace("\"", ""));
                resultItem.Add("dbUpdateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                uramonJsonList.Add(resultItem);
            }
            result.Add("dataList", uramonJsonList);

            return result.ToString();
        }
    }
}
