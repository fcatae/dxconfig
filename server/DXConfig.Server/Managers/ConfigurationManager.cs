using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Managers
{
    public class ConfigurationManager
    {
        public void Create(string application, string environment, string secrets)
        {
        }

        public string Retrieve(string application, string environment)
        {
            return "{secrets: true}";
        }
    }
}
