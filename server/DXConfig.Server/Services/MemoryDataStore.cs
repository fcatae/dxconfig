using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{
    public class MemoryDataStore : IDataStore, IStoreServices
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

        #region LEGACY

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

        #endregion
    }
}
