
using DataStandardSystem.Config;
using DataStandardSystem.Data;
using DataStandardSystem.Data.Paser;
using DataStandardSystem.Import;
using DataStandardSystem.Network.RestApi;
using DataStandardSystem.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataStandardSystem.SystemManager
{
    class DataStandardManger
    {
        // type별 데이터 Import
        DoserateImport doserateImport = new DoserateImport();
        RestApi restApi = new RestApi();

        public void RunCollectionImportData() 
        {
            //선량률 데이터 수집
            doserateImport.DoserateDataConllection(ConfigManager.GetInstance().doserateConfig, restApi);

            //기타 데이터 수집
        }

    }
}
