using System;
using System.Collections.Generic;
using System.Linq;
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

        public User Create(string provider, string username)
        {
            string userString = $"{provider}:{username}";

            var hashKey = _passKeyServices.Create(userString) as IHashKey;

            if( hashKey == null )
                throw new InvalidOperationException("_passKeyServices.Create does not return IHashKey");

            return new User(provider, username, hashKey.Hash);
        }

        public bool Validate(User user)
        {
            var sameUser = Create(user.Provider, user.Name);

            return (user.Hash == sameUser.Hash);
        }
    }

}
