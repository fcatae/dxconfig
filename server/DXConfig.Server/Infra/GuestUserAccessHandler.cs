using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using Microsoft.AspNetCore.Http;

namespace DXConfig.Server.Infra
{
    public class GuestUserAccessHandler : IUserAccessHandler
    {
        private readonly HttpContext _context;
        private readonly IUserManager _userManager;

        public GuestUserAccessHandler(IUserManager userManager)
        {
            this._userManager = userManager;
        }

        public User GetUser()
        {
            return null;
        }

    }
}
