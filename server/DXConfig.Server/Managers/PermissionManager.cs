using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Managers
{
    public class AppResourcePermissionManager : IPermissionManager<AppResource>
    {
        public bool HasAccess(AppResource resource, IPassKey passKey)
        {
            return true;
        }
    }
}
