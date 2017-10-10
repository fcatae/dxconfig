using DXConfig.Server.Managers;
using DXConfig.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Validations
{
    public class ValidateUserManager
    {
        public void Validate()
        {
            JwtTokenKeyServices jwtServices = new JwtTokenKeyServices("123");
            UserManager userManager = new UserManager(jwtServices);

            var user = userManager.CreateUser("test", "usertest");

            string serializedUser = userManager.ExportUser(user);

            var user1 = userManager.ImportUser(serializedUser);
        }
    }
}
