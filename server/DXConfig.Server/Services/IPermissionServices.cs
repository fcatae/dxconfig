using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{
    public interface IPermissionServices<T>
        where T: IResource
    {
        bool HasAccess(T resource, IPassKey passKey);
    }
}
