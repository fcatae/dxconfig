using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Managers
{
    public class StorageManager : IStorageManager
    {
        public IData Read(string container, IPassKey key)
        {
            throw new NotImplementedException();
        }

        public void Write(string container, IPassKey key, IData data)
        {
            throw new NotImplementedException();
        }
    }
}
