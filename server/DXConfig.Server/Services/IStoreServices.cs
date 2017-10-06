using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Services
{
    public interface IStoreServices
    {
        void Write(string containerName, IData containerData, IPasskey key);
        IData Read(string containerName, IPasskey key);
    }
}
