using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Interfaces
{
    public interface ILocatorManager
    {
        string Find(string appid, string environment);
        string SecureFind(string user, string appid, string environment);
    }
}
