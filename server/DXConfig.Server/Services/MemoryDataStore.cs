using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;

namespace DXConfig.Server.Services
{
    public class MemoryDataStore : IDataStore
    {
        public IConfigData Read(string containerName)
        {
            return new Models.ConfigData();
        }
    }
}
