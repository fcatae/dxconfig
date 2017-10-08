using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Managers
{
    public interface IStorageManager
    {
        IData Read(IUser user, string container);
        void Write(IUser user, string container, IData data);
    }
}
