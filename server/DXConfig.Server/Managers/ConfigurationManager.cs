using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;
using DXConfig.Server.Services;

namespace DXConfig.Server.Managers
{
    public class ConfigurationManager
    {
        IDataStore _dataStore = new MemoryDataStore();

        public void Create(string application, string environment, string secrets)
        {
        }

        public string Retrieve(string application, string environment)
        {
            MemoryDataStore dataStore = (MemoryDataStore)_dataStore;

            string containerName = application + "/" + environment;

            var data = dataStore.Read(containerName);

            return data.ToString();
        }
    }
}
