using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DXConfig.Server.Models;

namespace DXConfig.Server.Services
{
    public abstract partial class PassKeyServices
    {
        public class HashedData
        {
            public HashedData(byte[] bytes)
            {
                Bytes = bytes;
            }

            public byte[] Bytes { get; }

            public string Base64 => Convert.ToBase64String(this.Bytes);

            public string Hex => this.Bytes.ToString();
        }

        public interface IHash
        {
            HashedData Hash(string value);
        }

        protected static class Hash
        {
            public static IHash Sha256(string secret) => new HashSha256(secret);
        }

        protected class HashSha256 : IHash
        {
            HashAlgorithm _encryptionKey;

            public HashSha256(string secret)
            {
                _encryptionKey = CreateEncryptionKey(secret);
            }

            public HashedData Hash(string value)
            {
                byte[] data = Encoding.UTF8.GetBytes(value);

                byte[] hash = _encryptionKey.ComputeHash(data);

                return new HashedData(hash);                
            }

            HashAlgorithm CreateEncryptionKey(string secret)
            {
                var key = Encoding.UTF8.GetBytes(secret);
                HMACSHA256 hmacSha = new HMACSHA256(key);

                return hmacSha;
            }
        }

    }
}
