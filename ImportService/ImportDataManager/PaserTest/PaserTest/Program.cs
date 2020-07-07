using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace PaserTest
{
    class Program
    {
        static void Main(string[] args)
        {

            jsonParser json = new jsonParser();
            json.JsonParsorTest();

            xmlParser xml = new xmlParser();
            //xml.XmlParsorTest();

            DateTime dt = DateTime.Now;
            dt = dt.AddMinutes(-(dt.Minute % 10));
            while (true)
            {
                if (dt.Ticks < DateTime.Now.Ticks)
                {
                    dt = dt.AddMinutes(2);
                    //Tester.insertDataforThread();
                    Console.WriteLine("실행" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("쉬고싶당" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                }
            }

        }
    }
}
