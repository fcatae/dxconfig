using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{
    public class MemoryDataStore : IStoreServices
    {
        Dictionary<string, IData> _store = new Dictionary<string, IData>();

        public void WriteData(string containerName, IData containerData)
        {
            _store[containerName] = containerData;
        }

        public IData ReadData(string containerName)
        {
            IData data = null;

            _store.TryGetValue(containerName, out data);

            return data;
        }
    }
}
