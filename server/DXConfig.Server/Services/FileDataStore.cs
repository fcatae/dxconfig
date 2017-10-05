using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;

namespace DXConfig.Server.Services
{
    public class FileDataStore : IDataStore
    {
        public IConfigData Read(string containerName)
        {
            throw new NotImplementedException();
        }

        public void Write(string containerName, IConfigData containerData)
        {
            throw new NotImplementedException();
        }
    }
}
