using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{
    public interface IStoreServices
    {
        IData ReadData(string containerName);
        void WriteData(string containerName, IData containerData);
    }
}
