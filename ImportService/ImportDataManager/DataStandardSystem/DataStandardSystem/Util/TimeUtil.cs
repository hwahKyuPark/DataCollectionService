using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStandardSystem.Util
{
    public class TimeUtil
    {
        public DateTime CheckTime(String type,int interval) 
        {
            DateTime checkTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);

            if (type == "HOUR")
                checkTime = checkTime.AddHours(-(checkTime.Hour % interval));
            else if(type == "MINUTE")
                checkTime = checkTime.AddMinutes(-(checkTime.Minute % interval));
            
            return checkTime;
        }

        public DateTime InitTime() 
        {
            DateTime initTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            return initTime;
        }
    }
}
