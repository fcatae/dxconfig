using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{    
    public partial class PassKeyServices : IPassKeyServices
    {
        IHash _calculate;
        protected ITextSerializer _text;
        protected ByteConverterDelegate _convertToString;

        public PassKeyServices(string secrets) 
            : this( Hash.Sha256(secrets), Hash.Base64Url, Text.UrlEncoder )
        {
        }

        protected PassKeyServices(IHash calculate, ByteConverterDelegate convertToString, ITextSerializer text)
        {
            _calculate = calculate;
            _text = text;
            _convertToString = convertToString;
        }

        public IPassKey CreateKey(params string[] components)
        {
            string value = Serialize(components);

            return CreateHash(value);
        }

        protected virtual string Serialize(string[] components)
        {
            string[] safeComponents = _text.Encode(components);

            return String.Join(':', safeComponents);
        }

        protected virtual string[] Deserialize(string text)
        {
            string[] components = text.Split(':');

            return _text.Decode(components);
        }

        protected IPassKey CreateHash(string value)
        {
            return new HashKey(value, HashString(value));
        }

        string HashString(string value)
        {
            byte[] data = _calculate.Hash(value).Bytes;

            return _convertToString(data);
        }

        public bool ValidateKey(IPassKey key)
        {
            if (key == null)
                return false;

            string value = key.Value;
            string hash = key.Hash;

            return (hash == HashString(value));
        }
    }
}
