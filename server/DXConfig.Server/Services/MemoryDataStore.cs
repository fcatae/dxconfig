using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;

namespace DXConfig.Server.Services
{
    public class MemoryDataStore : IDataStore
    {
        Dictionary<string, IConfigData> _internal = new Dictionary<string, IConfigData>();

        public void Write(string containerName, IConfigData containerData)
        {
            _internal[containerName] = containerData;
        }

        public IConfigData Read(string containerName)
        {
            IConfigData data = null;

            _internal.TryGetValue(containerName, out data);
                
            return data;
        }
    }
}
