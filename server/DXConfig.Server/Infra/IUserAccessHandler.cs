using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Infra
{
    public interface IUserAccessHandler
    {
        User GetUser();
    }
}
