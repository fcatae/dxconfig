using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{    
    public partial class PassKeyServices : IPassKeyServices
    {
        private IHash _calculate;
        private ITextSerializer _text;
        private ByteConverterDelegate _convertToString;

        protected IHash HashAlgorithm => _calculate;
        protected ITextSerializer Text => _text;

        public PassKeyServices(string secrets) 
            : this( Hash.Sha256(secrets), Hash.Base64Url, Encoder.Url )
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

            var key = CreateHash(value);

            return TransformKey(key);
        }

        protected virtual string Serialize(string[] components)
        {
            string[] safeComponents = _text.Encode(components);

            return String.Join('.', safeComponents);
        }

        protected virtual string[] Deserialize(string text)
        {
            string[] components = text.Split('.');

            return _text.Decode(components);
        }

        public virtual IPassKey ImportKey(string text)
        {
            return CreateHash(text);
        }

        public virtual string ExportKey(IPassKey key)
        {
            return key.Value;
        }

        public string[] GetComponents(IPassKey key)
        {
            string[] valuesBase64 = Deserialize(key.Value);

            return _text.Decode(valuesBase64);
        }

        protected IPassKey CreateHash(string value)
        {
            return new HashKey(value, HashString(value));
        }

        protected virtual IPassKey TransformKey(IPassKey passKey)
        {
            return passKey;
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
