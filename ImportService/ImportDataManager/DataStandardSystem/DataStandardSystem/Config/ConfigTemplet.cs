using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStandardSystem.Config
{
    public abstract class ConfigTemplet
    {
        public void CreateDirectory(String fileName) 
        {
            try 
            {
                String path = Application.StartupPath + @"\Config\"+fileName+".json";

                if (File.Exists(path) == true)
                    return;

                DirectoryInfo directory = new DirectoryInfo(Application.StartupPath + @"/Config/");
                if (directory.Exists == false)
                    directory.Create();

                // 파일 쓰기 
                this.WriteFile(fileName);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public abstract bool WriteFile(String fileName);
        public abstract bool ReadFile(String fileName); 
        
    }
}
