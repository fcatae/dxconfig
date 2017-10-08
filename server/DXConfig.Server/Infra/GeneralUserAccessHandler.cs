using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace DXConfig.Server.Infra
{
    public class GeneralUserAccessHandlerOptions
    {
        public string Provider { get; set; }
        public string Username { get; set; }
    }

    public class GeneralUserAccessHandler : IUserAccessHandler
    {
        private readonly User _user;

        public GeneralUserAccessHandler(IUserManager userManager, IOptions<GeneralUserAccessHandlerOptions> options)
        {
            string provider = options.Value.Provider ?? "test";
            string username = options.Value.Username;
            
            _user = (username != null) ? userManager.CreateUser(provider, username) : null;
        }

        public User GetUser()
        {
            return _user;
        }

    }
}
