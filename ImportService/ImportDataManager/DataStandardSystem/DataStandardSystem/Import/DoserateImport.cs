using DataStandardSystem.Config;
using DataStandardSystem.Data;
using DataStandardSystem.Data.Paser;
using DataStandardSystem.Data.Paser.Site.Json;
using DataStandardSystem.Data.Paser.Site.Xml;
using DataStandardSystem.Network.RestApi;
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
using System.Threading;
using System.Threading.Tasks;

namespace DataStandardSystem.Import
{
    public class DoserateImport
    {
        public void DoserateDataConllection(DoserateConfig doserateConfig, RestApi restApi)
        {
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                if (doserateConfig.configInfo.SiteInfo.Count == 0)
                    return;

                DateTime KaeriCheckTime = UtilManager.GetInstance().TimeUtil.InitTime();
                DateTime uRamonCheckTime = UtilManager.GetInstance().TimeUtil.InitTime();
                DateTime khnpCheckTime = UtilManager.GetInstance().TimeUtil.InitTime();
                DateTime kinsCheckTime = UtilManager.GetInstance().TimeUtil.InitTime();

                foreach (JObject checkType in doserateConfig.configInfo.SiteInfo)
                {
                    if (checkType["offer"].ToString().Replace("\"", "").Equals(ConfigManager.ImportType.KAERI.ToString()))
                        KaeriCheckTime = UtilManager.GetInstance().TimeUtil.CheckTime("MINUTE", Int32.Parse(checkType["interval"].ToString()));

                    if (checkType["offer"].ToString().Replace("\"", "").Equals(ConfigManager.ImportType.URAMON.ToString()))
                        uRamonCheckTime = UtilManager.GetInstance().TimeUtil.CheckTime("MINUTE", Int32.Parse(checkType["interval"].ToString()));

                    if (checkType["offer"].ToString().Replace("\"", "").Equals(ConfigManager.ImportType.KHNP.ToString()))
                        khnpCheckTime = UtilManager.GetInstance().TimeUtil.CheckTime("MINUTE", Int32.Parse(checkType["interval"].ToString()));

                    if (checkType["offer"].ToString().Replace("\"", "").Equals(ConfigManager.ImportType.KINS.ToString()))
                        kinsCheckTime = UtilManager.GetInstance().TimeUtil.CheckTime("MINUTE", Int32.Parse(checkType["interval"].ToString()));
                }
                
                while (true)
                {
                    Thread.Sleep(1000);

                    try 
                    {
                        foreach (JObject info in doserateConfig.configInfo.SiteInfo) 
                        {
                            if (info["offer"].ToString().Replace("\"", "").Equals("KAERI"))
                            {
                                if (KaeriCheckTime <= DateTime.Now)
                                {
                                    String url = info["url"].ToString().Replace("\"", "");
                                    String insertData = Site.SiteParser("KAERI").GetPaserDataList(url);

                                    restApi.Post(doserateConfig.configInfo.PostURL, "application/json", insertData);

                                    KaeriCheckTime = KaeriCheckTime.AddMinutes(Int32.Parse(info["interval"].ToString()));
                                }
                            }

                            if (info["offer"].ToString().Replace("\"", "").Equals("URAMON"))
                            {
                                if (uRamonCheckTime <= DateTime.Now) 
                                {
                                    String url = info["url"].ToString().Replace("\"", "");
                                    String insertData = Site.SiteParser("URAMON").GetPaserDataList(url);

                                    restApi.Post(doserateConfig.configInfo.PostURL, "application/json", insertData);

                                    uRamonCheckTime = uRamonCheckTime.AddMinutes(Int32.Parse(info["interval"].ToString()));                                   
                                }
                            }

                            if (info["offer"].ToString().Replace("\"", "").Equals("KHNP"))
                            {
                                if (khnpCheckTime <= DateTime.Now) 
                                {
                                    String url = info["url"].ToString().Replace("\"", "");
                                    String insertData = Site.SiteParser("KHNP").GetPaserDataList(url);

                                    restApi.Post(doserateConfig.configInfo.PostURL, "application/json", insertData);

                                    khnpCheckTime = khnpCheckTime.AddMinutes(Int32.Parse(info["interval"].ToString()));                            
                                }
                            }

                            if (info["offer"].ToString().Replace("\"", "").Equals("KINS"))
                            {
                                if (kinsCheckTime <= DateTime.Now)
                                {
                                    String url = info["url"].ToString().Replace("\"", "");
                                    String insertData = Site.SiteParser("KINS").GetPaserDataList(url);

                                    restApi.Post(doserateConfig.configInfo.PostURL, "application/json", insertData);

                                    kinsCheckTime = kinsCheckTime.AddMinutes(Int32.Parse(info["interval"].ToString()));
                                
                                }
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("오류 메시지 ::::DoserateDataConllection()");
                        Console.WriteLine(e.Message);
                    }       
                }
            });
        }
    }
}
