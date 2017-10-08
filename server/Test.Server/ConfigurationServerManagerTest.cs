using System;
using System.Collections.Generic;
using System.Text;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using DXConfig.Server.Services;
using Xunit;

namespace Test.Server
{
    public class ConfigurationServerManagerTest
    {
        void SimpleTest()
        {
            var location = new AppResourceLocationManager();
            var storage = new StorageManager();

            var userMgr = new UserManager(new PassKeyServices("123"));

            var csm = new ConfigServerManager<AppResource>(location, storage);

            var user = userMgr.CreateUser("test", "fabricio");

            csm.Create(user, new AppResource("webapp001", "dev"), new StringData("secrets"));
            var res = csm.Retrieve(user, new AppResource("webapp001", "dev"));

            Assert.Equal(res.ToString(), "secrets");
        }
    }
}
