using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Interfaces;

namespace DXConfig.Server.Models
{
    public class SecureData : IConfigData
    {
        IConfigData _data;
        string _key;

        public SecureData(IConfigData data, string key)
        {
            this._data = data;
            this._key = key;
        }

        public IConfigData Unlock(string key)
        {
            if (key != _key)
                return null;

            return _data;
        }
    }
}
