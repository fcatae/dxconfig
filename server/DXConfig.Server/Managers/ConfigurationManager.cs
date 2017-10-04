using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;
using DXConfig.Server.Models;
using DXConfig.Server.Services;

namespace DXConfig.Server.Managers
{
    public class ConfigurationManager : IConfigurationManager
    {
        IDataStore _dataStore;

        public ConfigurationManager(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void Create(string application, string environment, string secrets)
        {
            MemoryDataStore dataStore = (MemoryDataStore)_dataStore;

            string containerName = application + "/" + environment;

            dataStore.Write(containerName, new ConfigData());
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
