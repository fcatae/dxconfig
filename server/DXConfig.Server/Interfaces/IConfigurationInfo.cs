using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Interfaces
{
    interface IConfigurationInfo
    {
        string Application { get; set; }
        string Environment { get; set; }
        string Component { get; set; }
    }
}
