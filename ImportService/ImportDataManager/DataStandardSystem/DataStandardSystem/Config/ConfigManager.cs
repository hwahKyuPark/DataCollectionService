
using DataStandardSystem.Config.Doserate;
using DataStandardSystem.Tool;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStandardSystem.Config
{
    public class ConfigManager : Singleton<ConfigManager>
    {
        public DoserateConfig doserateConfig = new DoserateConfig();

        public enum ImportType
        {
            KAERI,
            KINS,
            KHNP,
            URAMON
        }

        public ConfigManager() 
        {
            // 선량률 type Config 파일 Create / Read
            doserateConfig.CreateDirectory("doserate");
            doserateConfig.ReadFile("doserate");
        }

        public ArrayList DoserateSiteInfo() 
        {
            return doserateConfig.configInfo.SiteInfo;
        }
    }
}
