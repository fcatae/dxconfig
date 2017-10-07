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
        [Fact(Skip="still working on")]
        void Test()
        {
            var location = new LocationManager();
            var storage = new StorageManager();

            var userMgr = new UserManager(new PassKeyServices("123"));

            var csm = new ConfigurationServerManager<IResource>(location, storage);

            var user = userMgr.CreateUser("test", "fabricio");

            csm.Create(null, null, null);
            csm.Retrieve(null, null);
        }
    }
}
