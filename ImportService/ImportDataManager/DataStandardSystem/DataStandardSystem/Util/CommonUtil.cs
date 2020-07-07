using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStandardSystem.Util
{
    public class CommonUtil
    {
        public String GetUniqueKey() 
        {
            return Guid.NewGuid().ToString();
        }
    }
}
