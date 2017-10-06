using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Interfaces
{
    public interface ISecureDataStore
    {
        void Write(string containerName, IConfigData containerData, string key);
        IConfigData Read(string containerName, string key);
    }
}
