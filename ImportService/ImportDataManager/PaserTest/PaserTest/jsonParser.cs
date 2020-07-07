using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaserTest
{
    class jsonParser
    {
        public void JsonParsorTest() 
        {

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    webClient.Encoding = Encoding.UTF8;

                    //String jsonURL = "http://59.24.28.107:9090/OpenApi/Export/Json/d6985e3922e24283be8c670ffb4e326a";
                    // String -> JArray                   

                    String jsonURL = "https://www.kaeri.re.kr/api/erm/json";
                    // String -> Json(파서 후) -> String -> JArray
                    
                    String strJsonURLData = webClient.DownloadString(jsonURL);

                    Object json = JObject.Parse(strJsonURLData);

                    String strJsonData = JsonConvert.SerializeObject(json);
                     JArray array = JArray.Parse(strJsonURLData);
                   

                    foreach (JObject parsorItem in array)
                    {
                        String name = parsorItem["name"].ToString();
                        Console.WriteLine(name.Replace("\"", ""));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                //Debug.WriteLine(strJsonData);
             }


            /*
            using(WebClient webClient = new WebClient())
            {
                try
                {
                    webClient.Encoding = Encoding.UTF8; 

                    String jsonURL = "http://59.24.28.107:9090/OpenApi/Export/Json/d6985e3922e24283be8c670ffb4e326a";
                    // String -> Json(파서 후) -> String -> JArray 

                    //String jsonURL = "https://www.kaeri.re.kr/api/erm/json";
                    // String -> JArray
                    String strJsonURLData = webClient.DownloadString(jsonURL);

                    JObject json = JObject.Parse(strJsonURLData);

                    String strJsonData = JsonConvert.SerializeObject(json["openApiExportDeviceList"]);
                    JArray array = JArray.Parse(strJsonData);
                    Debug.WriteLine(strJsonData);

                    foreach(JObject parsorItem in array)
                    {
                        String name = parsorItem["name"].ToString();
                        Console.WriteLine(name.Replace("\"",""));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            //Debug.WriteLine(strJsonData);
            }
            */
        }
    }
}
