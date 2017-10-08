﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using Microsoft.AspNetCore.Http;

namespace DXConfig.Server.Infra
{
    public class UserAccessHandler : IUserAccessHandler
    {
        private readonly HttpContext _context;
        private readonly IUserManager _userManager;

        public UserAccessHandler(IHttpContextAccessor accessor, IUserManager userManager)
        {
            this._context = accessor.HttpContext;
            this._userManager = userManager;
        }

        public User GetUser()
        {
            if( _context.User != null && _context.User.Identity.IsAuthenticated )
            {
                string username = _context.User.Identity.Name;

                return _userManager.CreateUser("test", username);
            }

            return null;
        }

    }
}