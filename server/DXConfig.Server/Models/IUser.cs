using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Models
{
    public interface IUser
    {
        string Provider { get; }
        string Name { get; }
        IPassKey Key { get; }
        IPassKey ExtraKey { get; }
    }
}
