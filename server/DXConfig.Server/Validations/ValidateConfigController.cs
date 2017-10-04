using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Controllers;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using DXConfig.Server.Services;

namespace DXConfig.Server.Validations
{
    public class ValidateConfigController
    {
        public void Validate()
        {
            var initialData = new ConfigData();
            var store = new MemoryDataStore();

            // Try read "myapp001": no secrets
            var configData1 = store.Read("myapp001");

            // Write secrets
            store.Write("myapp001", initialData);

            // Try read "myapp001": should return value
            var configData2 = store.Read("myapp001");

            // Test controller
            var dataStore = new MemoryDataStore();
            dataStore.Write("myapp001/prod", new ConfigData());
            var configMgr = new ConfigurationManager(dataStore);

            configMgr.Create("myapp001", "dev", "{<<devsecrets>>}");

            var controller = new ConfigController(configMgr);
            string secrets = controller.Get("myapp001");

            Console.WriteLine($"Secrets for myapp001: {secrets}");
        }
    }
}
