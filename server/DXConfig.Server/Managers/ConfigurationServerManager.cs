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

        public ConfigurationServerManager(ILocationManager<T> location, IStorageManager store)
        {
            this._locator = location;
            this._store = store;
        }

        public void Create(IUser user, T resource, IData config)
        {
            string container = _locator.Create(user, resource);

            if (container == null)
            {
                // already exists?
                throw new InvalidOperationException("container == null");
            }

            _store.Write(user, container, config);
        }

        public IData Retrieve(IUser user, T resource)
        {
            string container = _locator.Resolve(user, resource);

            // container not found
            if (container == null)
                return null;

            var data = _store.Read(user, container);

            // data could not be retrieved
            if (data == null)
                return null;

            return data;
        }
    }
}
