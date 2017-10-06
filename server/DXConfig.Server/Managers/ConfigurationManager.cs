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
        INameResolver _nameResolver;
        ISecureDataStore _secureDataStore;

        public ConfigurationManager(INameResolver nameResolver, IDataStore dataStore, ISecureDataStore secureDataStore)
        {
            _dataStore = dataStore;
            _nameResolver = (ApplicationResolver)nameResolver;
            _secureDataStore = secureDataStore;
        }

        public void Create(string application, string environment, string secrets)
        {
            string key = "SECRETGENERATED";

            string containerName = _nameResolver.Resolve(application, environment);
            
            _dataStore.Write(containerName, new StringData(key));
            _secureDataStore.Write(containerName, new ConfigData(), key);
        }

        public string Retrieve(string application, string environment)
        {
            string containerName = _nameResolver.Resolve(application, environment);

            // container name not found
            if (containerName == null)
                return null;

            // read key
            var keydata = _dataStore.Read(containerName);

            if (keydata == null)
                return null;

            string key = keydata.ToString();

            // read data
            var data = _secureDataStore.Read(containerName, key);

            if (data == null)
                return null;

            return data.ToString();
        }
    }
}
