using DXConfig.Server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Services
{
    public class JwtTokenKeyServices : PassKeyServices
    {
        private readonly string _jwtHeaderBase64;

        public JwtTokenKeyServices(string secrets) : base(Hash.Sha256(secrets), Hash.Base64Url, Encoder.Base64Url)
        {
            string algorithm = HashAlgorithm.Algorithm;

            _jwtHeaderBase64 = EncodeBase64($"{{\"alg\": \"{algorithm}\", \"typ\": \"JWT\"}}");
        }

        protected override string Serialize(string[] components)
        {
            string singleLine = components[0];

            singleLine = String.Join('\n', components);

            string payloadBase64 = EncodeBase64(singleLine);            

            return $"{_jwtHeaderBase64}.{payloadBase64}";
        }

        protected override string[] Deserialize(string text)
        {
            string[] payloads = text.Split('.');
            string jwt64 = payloads[0];
            string data64 = payloads[1];
            // ignore payloads[2..]

            string data = DecodeBase64(data64);

            return data.Split('\n');
        }

        protected override IPassKey TransformKey(IPassKey passKey)
        {
            return new JwtTokenKey(passKey.Value, passKey.Hash);
        }

        private string EncodeBase64(string text)
        {
            return this.Text.Encode(new string[] { text })[0];
        }

        private string DecodeBase64(string text)
        {
            return this.Text.Decode(new string[] { text })[0];
        }

        public override IPassKey ImportKey(string text)
        {
            string[] jwtComponents = text.Split('.');
            string value = jwtComponents[1];

            return CreateKey(value);
        }

        public override string ExportKey(IPassKey key)
        {
            return $"{key.Value}.{key.Hash}";
        }
    }
}
