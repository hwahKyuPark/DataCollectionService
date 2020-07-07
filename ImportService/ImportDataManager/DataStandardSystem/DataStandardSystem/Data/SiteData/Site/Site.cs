using DataStandardSystem.Data.Paser;
using DataStandardSystem.Data.Paser.Site.Json;
using DataStandardSystem.Data.Paser.Site.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStandardSystem.Util
{
    static class Site
    {
        internal static Parser SiteParser(String type) 
        {
            if (type == "KAERI")
                return new KaeriJSON();
            else if (type == "KINS")
                return new KinsXML();
            else if (type == "KHNP")
                return new KhnpXML();
            else if (type == "URAMON")
                return new UramonJSON();
            
            return null;
        }
    }
}
