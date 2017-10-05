using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;

namespace DXConfig.Server.Managers
{
    public class LocatorManager : ILocatorManager
    {
        public string Find(string appid)
        {
            if (appid == null)
                throw new ArgumentNullException("appid");

            return appid;
        }

        public string Find(string appid, string optEnvironment)
        {
            if (appid == null)
                throw new ArgumentNullException("appid");

            if (optEnvironment == null)
                throw new ArgumentNullException("optEnvironment");

            return $"{appid}/{optEnvironment}";
        }
    }
}
