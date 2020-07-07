using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStandardSystem.Config.Doserate
{
    public class DoserateConfigData
    {
        private String postURL;
        private ArrayList siteInfo = new ArrayList();

        public DoserateConfigData()
        {
            postURL = "";

            JObject jsonSiteInfo = new JObject();
            jsonSiteInfo.Add("offer", "");
            jsonSiteInfo.Add("url", "");
            jsonSiteInfo.Add("interval", 0);

            siteInfo.Add(jsonSiteInfo);
        }

        public ArrayList SiteInfo
        { 
            get { return siteInfo; }
            set { siteInfo = value; } 
        }

        public String PostURL
        {
            get { return postURL; }
            set { postURL = value; }
        }

    }
}
