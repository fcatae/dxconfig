using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Managers
{
    public interface IStorageManager
    {
        IData Read(string container, IPassKey key);
        void Write(string container, IData data, IPassKey key);
    }
}
