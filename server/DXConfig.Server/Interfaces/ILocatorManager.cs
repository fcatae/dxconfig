using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Interfaces
{
    public interface ILocatorManager
    {
        string Find(string appid);
        string Find(string appid, string optEnvironment);
    }
}
