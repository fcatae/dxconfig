using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{
    public class SecureDataStore : ISecureDataStore
    {
        private IDataStore _dataStore;

        public SecureDataStore(IDataStore dataStore)
        {
            if (dataStore == null)
                throw new ArgumentNullException(nameof(dataStore));

            this._dataStore = dataStore;
        }

        public IConfigData Read(string containerName, string key)
        {
            SecureData secureData = (SecureData)_dataStore.Read(containerName);

            if (secureData == null)
                return null;

            return secureData.Unlock(key);
        }

        public void Write(string containerName, IConfigData containerData, string key)
        {
            var secureData = new SecureData(containerData, key);
            _dataStore.Write(containerName, secureData);
        }
    }
}
