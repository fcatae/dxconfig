using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Models
{
    public class AppResource : IResource
    {
        public string Name { get; }
        public string Environment { get; }
        
        public AppResource(string name, string environment)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (environment == null)
                throw new ArgumentNullException(nameof(environment));

            this.Name = name;
            this.Environment = environment;
        }
    }
}
