using System;
using System.Collections.Generic;
using System.Text;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using DXConfig.Server.Services;
using Xunit;

namespace Test.Server
{
    public class UserManagerTest
    {
        private UserManager _userManager;

        public UserManagerTest()
        {
            IPassKeyServices hashServices = new JwtTokenKeyServices("123");
            this._userManager = new UserManager(hashServices);
        }

        [Fact]
        public void TestUserSerialization()
        {
            UserManager userManager = _userManager;

            var user1 = userManager.CreateUser("git:git", "comp1:comp2");

            // serialize
            string serialization1 = userManager.ExportUser(user1);

            // deserialize
            var sameUser1 = userManager.ImportUser(serialization1);

            Assert.NotNull(sameUser1);

            Assert.Equal(user1.Provider, sameUser1.Provider);
            Assert.Equal(user1.Name, sameUser1.Name);
            Assert.Equal(user1.Key.Hash, sameUser1.Key.Hash);

            // userManager recognizes it as the same user1
            Assert.True(userManager.Validate(sameUser1));
        }

        [Fact]
        public void TestUserManager()
        {
            UserManager userManager = _userManager;

            var user1 = userManager.CreateUser("git", "fabricio");
            
            IPassKeyServices otherHashServices = new PassKeyServices("abc");
            UserManager otherUserManager = new UserManager(otherHashServices);

            // create a similar user
            var otherUser = otherUserManager.CreateUser("git", "fabricio");

            // almost the same characteristics 
            Assert.Equal(user1.Provider, otherUser.Provider);
            Assert.Equal(user1.Name, otherUser.Name);
            // except for the hash
            Assert.NotEqual(user1.Key.Hash, otherUser.Key.Hash);

            Assert.False(userManager.Validate(otherUser));
        }

        //[Fact]
        //public void TestCreateSecret()
        //{
        //    var secret = _userManager.CreateSecret("abc");

        //    Assert.NotNull(secret);

        //    Assert.Equal(secret.Provider, UserManager.SecretProvider);
        //    Assert.NotEqual(secret.Name, "abc");
        //    Assert.NotNull(secret.Key);
        //}
    }
}
