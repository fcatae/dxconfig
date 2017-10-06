using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Services
{
    public interface INameServices<T>
    {
        string Resolve(T component);
    }
}
