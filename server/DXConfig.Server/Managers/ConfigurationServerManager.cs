using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Managers
{
    public class ConfigurationServerManager<T> : IConfigurationServerManager<T>
        where T: IResource
    {
        private ILocationManager<T> _locator;
        private IStorageManager _store;

        public ConfigurationServerManager(ILocationManager<T> locator, StorageManager store)
        {
            this._locator = locator;
            this._store = store;
        }

        public void Create(IUser user, T resource, IData config)
        {
            IPassKey key = user.Key;

            string container = _locator.Create(resource, key);

            if (container == null)
            {
                // already exists?
                throw new InvalidOperationException("container == null");
            }

            _store.Write(container, config, key);
        }

        public IData Retrieve(IUser user, T resource)
        {
            IPassKey key = user.Key;

            string container = _locator.Resolve(resource, key);

            // container not found
            if (container == null)
                return null;

            var data = _store.Read(container, key);

            // data could not be retrieved
            if (data == null)
                return null;

            return data;
        }
    }
}
