using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;

namespace DXConfig.Server.Services
{
    public class ApplicationResolver : INameResolver
    {
        public string Resolve(string application, string environment)
        {
            string name = application + "/" + environment;

            return ConvertToBase64(name);
        }

        string ConvertToBase64(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);

            return Convert.ToBase64String(data);
        }
    }
}
