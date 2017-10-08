﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Controllers;
using DXConfig.Server.Infra;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using DXConfig.Server.Services;

namespace DXConfig.Server.Validations
{
    public class ValidateConfigController
    {
        class FakeUAHandler : IUserAccessHandler
        {
            public User GetUser()
            {
                return null;
            }
        }
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
            //var dataStore = new MemoryDataStore();
            //var nameResolver = new ApplicationResolver();
            //dataStore.Write("myapp001/prod", new ConfigData());
            //var secureStore = new SecureDataStore(new MemoryDataStore());
            //var configMgr = new ConfigurationManager(nameResolver, dataStore, secureStore);

            //configMgr.Create("myapp001", "dev", "{<<devsecrets>>}");

            var location = new AppResourceLocationManager();
            var storage = new StorageManager();
            var configSrv = new ConfigServerManager<AppResource>(location, storage);
            
            IUser user = null;
            configSrv.Create(user, new AppResource("myapp001", "dev"), new StringData("{<<devsecrets>>}"));

            var controller = new ConfigController(configSrv, new FakeUAHandler());

            string secrets = controller.Get("myapp001");

            Console.WriteLine($"Secrets for myapp001: {secrets}");
        }
    }
}
