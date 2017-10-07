using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DXConfig.Server.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace DXConfig.Server.Services
{
    public partial class PassKeyServices
    {
        protected delegate string ByteConverterDelegate(byte[] data);

        protected class HashedData
        {
            public HashedData(byte[] bytes)
            {
                Bytes = bytes;
            }

            public byte[] Bytes { get; }
        }

        protected interface IHash
        {
            HashedData Hash(string value);
        }

        protected static class Hash
        {
            public static IHash Sha256(string secret) => new HashSha256(secret);
            
            public static string Base64(byte[] data) => Convert.ToBase64String(data);

            public static string Hex(byte[] data) => data.ToString();

            public static string Base64Url(byte[] data) => Base64UrlTextEncoder.Encode(data);
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

        protected interface ITextSerializer
        {
            string[] Decode(string[] components);
            string[] Encode(string[] components);
        }

        protected class Text
        {
            public static ITextSerializer UrlEncoder => new UrlTextEncoder();
        }

        protected class UrlTextEncoder : ITextSerializer
        {
            public string[] Decode(string[] components) => Apply(WebUtility.UrlDecode, components);

            public string[] Encode(string[] components) => Apply(WebUtility.UrlEncode, components);

            static string[] Apply(Func<string,string> func, string[] components)
            {
                var apply = components.Select(func);

                return apply.ToArray();
            }
        }
    }
}
