using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;

namespace DXConfig.Server.Services
{
    public class ApplicationResolver : INameResolver
    {
        public string Resolve(string application, string environment)
        {
            return application + "/" + environment;
        }
    }
}
