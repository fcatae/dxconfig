using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Models
{
    public class StringData : IData
    {
        private string _value;

        public StringData(string value)
        {
            this._value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
