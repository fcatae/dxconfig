using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{
    public interface IPassKeyServices
    {
        bool ValidateKey(IPassKey key);
    }
}
