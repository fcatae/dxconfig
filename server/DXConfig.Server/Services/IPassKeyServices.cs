using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{
    public interface IPassKeyServices
    {
        IPassKey CreateKey(params string[] components);
        bool ValidateKey(IPassKey key);
        string[] GetComponents(IPassKey key);
        IPassKey ImportKey(string text);
        string ExportKey(IPassKey key);
    }
}
