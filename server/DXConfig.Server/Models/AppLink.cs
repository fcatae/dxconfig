using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Models
{
    public class AppLink : IResource
    {
        public string Link { get; }

        public AppLink(string link)
        {
            if (link == null)
                throw new ArgumentNullException(nameof(link));
            
            this.Link = link;
        }
    }
}
