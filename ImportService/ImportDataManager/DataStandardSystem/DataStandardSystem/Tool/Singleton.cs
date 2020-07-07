using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStandardSystem.Tool
{
    public class Singleton<T> where T : class, new()
    {
        private static T _instance;
        private static object _synLock = new object();

        protected Singleton() { }

        public static T GetInstance()
        {
            if (_instance == null)
                _instance = new T();

            if (_instance == null)
            {
                lock (_synLock)
                {
                    _instance = new T();
                }
            }

            return _instance;
        }
    }
}
