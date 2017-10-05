using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;

namespace DXConfig.Server.Models
{
    public class ConfigData : IConfigData
    {
        public override string ToString()
        {
            return "{\"secrets\": true}";
        }
    }
}
