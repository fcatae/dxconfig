using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DXConfig.Server.Models;
using DXConfig.Server.Services;
using Newtonsoft.Json;

namespace DXConfig.Server.Managers
{
    public class UserManager : IUserManager
    {
        public const string SecretProvider = "SECRET";

        private IPassKeyServices _passKeyServices;

        public UserManager(IPassKeyServices passKeyServices)
        {
            this._passKeyServices = passKeyServices;
        }

        public User CreateUser(string provider, string username)
        {
            object objUser = new { provider=provider, user=username };
            string userString = JsonConvert.SerializeObject(objUser);
                
            var hashKey = _passKeyServices.CreateKey(userString);
            
            return new User(provider, username, hashKey);
        }

        //public User CreateSecret(string username, string secret)
        //{
        //    string secretString = $"{{string provider, user={username}, password={secret}}}";

        //    IPassKey secretKey = _passKeyServices.CreateKey(secret);

        //    string hash = secretKey.Hash;

        //    return CreateUser(SecretProvider, hash);
        //}

        //User CreateUser(string provider, string username, string keyValue, string keyHash)
        //{
        //    var hashKey = new HashKey(keyValue, keyHash);

        //    return new User(provider, username, hashKey);
        //}

        public bool Validate(User user)
        {
            return _passKeyServices.ValidateKey(user.Key);
        }

        public User ImportUser(string text)
        {
            if (text == null)
                return null;

            //string[] components = text.Split(":");

            //if (components.Length != 4)
            //    return null;

            //string provider = WebUtility.UrlDecode(components[0]);
            //string name = WebUtility.UrlDecode(components[1]);
            //string keyValue = WebUtility.UrlDecode(components[2]);
            //string keyHash = WebUtility.UrlDecode(components[3]);

            //return CreateUser(provider, name, keyValue, keyHash);

            //string[] components = _passKeyServices.GetComponents()

            var key = _passKeyServices.ImportKey(text);

            var components = _passKeyServices.GetComponents(key);


            dynamic objUser = JsonConvert.DeserializeObject(components[0]);

            string provider = objUser.provider;
            string name = objUser.user;

            return CreateUser(provider, name);
        }

        public string ExportUser(User user)
        {
            //string provider = WebUtility.UrlEncode(user.Provider);
            //string name = WebUtility.UrlEncode(user.Name);
            //string keyValue = WebUtility.UrlEncode(user.Key.Value);
            //string keyHash = WebUtility.UrlEncode(user.Key.Hash);
            //return $"{provider}:{name}:{keyValue}:{keyHash}";

            return _passKeyServices.ExportKey(user.Key);
        }
    }

}
