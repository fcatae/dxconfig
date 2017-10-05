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

        public ConfigurationManager(IDataStore dataStore, INameResolver nameResolver)
        {
            _dataStore = dataStore;
            _nameResolver = (ApplicationResolver)nameResolver;
        }

        public void Create(string application, string environment, string secrets)
        {
            string containerName = _nameResolver.Resolve(application, environment);

            _dataStore.Write(containerName, new ConfigData());
        }

        public string Retrieve(string application, string environment)
        {
            string containerName = _nameResolver.Resolve(application, environment);

            var data = _dataStore.Read(containerName);

            return data.ToString();
        }
    }
}
