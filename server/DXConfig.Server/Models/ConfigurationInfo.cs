using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Models
{
    public class ConfigurationInfo
    {
        public string Application { get; set; }
        public string Environment { get; set; }
        public string Component { get; set; }

        public string RetrieveSecrets()
        {
            return null;
        }
    }
}
