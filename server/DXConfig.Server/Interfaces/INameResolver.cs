using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Interfaces
{
    public interface INameResolver
    {
        string Resolve(string application, string environment);
    }
}
