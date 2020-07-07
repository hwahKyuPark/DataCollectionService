using DataStandardSystem.Config.Doserate;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class DoserateConfig : ConfigTemplet
    {
        public DoserateConfigData configInfo = new DoserateConfigData();

        public override bool WriteFile(String fileName)
        {
            try
            {
                using (StreamWriter file = File.CreateText(Application.StartupPath + @"\Config\" + fileName + ".json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, configInfo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }

        public override bool ReadFile(String fileName)
        {
            try
            {
                using (StreamReader file = File.OpenText(Application.StartupPath + @"\Config\" + fileName + ".json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    configInfo = (DoserateConfigData)serializer.Deserialize(file, typeof(DoserateConfigData));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }
    }
}
