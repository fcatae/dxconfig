using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DXConfig.Server.Models;
using DXConfig.Server.Services;

namespace DXConfig.Server.Managers
{
    public class UserManager
    {
        private IPassKeyServices _passKeyServices;

        public UserManager(IPassKeyServices passKeyServices)
        {
            this._passKeyServices = passKeyServices;
        }

        public User CreateUser(string provider, string username)
        {
            string userString = $"{provider}:{username}";

            var hashKey = _passKeyServices.CreateKey(userString);
            
            return new User(provider, username, hashKey);
        }

        User CreateUser(string provider, string username, string keyValue, string keyHash)
        {
            var hashKey = new HashKey(keyValue, keyHash);

            return new User(provider, username, hashKey);
        }

        public bool Validate(User user)
        {
            return _passKeyServices.ValidateKey(user.Key);
        }

        public User ImportUser(string text)
        {
            if (text == null)
                return null;

            string[] components = text.Split(":");

            if (components.Length != 4)
                return null;

            string provider = WebUtility.UrlDecode(components[0]);
            string name = WebUtility.UrlDecode(components[1]);
            string keyValue = WebUtility.UrlDecode(components[2]);
            string keyHash = WebUtility.UrlDecode(components[3]);

            return CreateUser(provider, name, keyValue, keyHash);
        }

        public string ExportUser(User user)
        {
            string provider = WebUtility.UrlEncode(user.Provider);
            string name = WebUtility.UrlEncode(user.Name);
            string keyValue = WebUtility.UrlEncode(user.Key.Value);
            string keyHash = WebUtility.UrlEncode(user.Key.Hash);

            return $"{provider}:{name}:{keyValue}:{keyHash}";
        }
    }

}
