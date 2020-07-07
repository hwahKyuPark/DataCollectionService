using DataStandardSystem.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStandardSystem.Util
{
    public class UtilManager : Singleton<UtilManager>
    {
        private TimeUtil timeUtil = new TimeUtil();
        private CommonUtil commonUtil = new CommonUtil();

        public TimeUtil TimeUtil
        {
            get { return timeUtil; }
            set { timeUtil = value; }
        }

        public CommonUtil CommonUtil
        {
            get { return commonUtil; }
            set { commonUtil = value; }
        }

    }
}
