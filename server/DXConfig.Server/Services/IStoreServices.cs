using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{
    public interface IStoreServices
    {
        void Write(string containerName, IData containerData, IPassKey key);
        IData Read(string containerName, IPassKey key);
    }
}
