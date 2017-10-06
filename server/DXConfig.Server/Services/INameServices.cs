using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{
    public interface INameServices<T> 
        where T : IResource
    {
        string Resolve(T component);
    }
}
