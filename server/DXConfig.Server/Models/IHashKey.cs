using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Models
{
    public interface IHashKey : IPassKey
    {
        string Hash { get; }
    }
}
