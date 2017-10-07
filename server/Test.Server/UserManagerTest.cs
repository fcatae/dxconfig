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
        [Fact]
        public void TestUserSerialization()
        {
            IPassKeyServices hashServices = new PassKeyServices("123");
            UserManager userManager = new UserManager(hashServices);

            var user1 = userManager.Create("git:git", "comp1:comp2");

            // serialize
            string serialization1 = user1.ToString();

            // deserialize
            var sameUser1 = userManager.ImportUser(serialization1);

            Assert.Equal(user1.Provider, sameUser1.Provider);
            Assert.Equal(user1.Name, sameUser1.Name);
            Assert.Equal(user1.Key.Hash, sameUser1.Key.Hash);

            // userManager recognizes it as the same user1
            Assert.True(userManager.Validate(sameUser1));
        }

        [Fact]
        public void TestUserManager()
        {
            IPassKeyServices hashServices = new PassKeyServices("123");
            UserManager userManager = new UserManager(hashServices);

            var user1 = userManager.Create("git", "fabricio");

            // serialize
            string serialization1 = user1.ToString();
            
            // deserialize
            var sameUser1 = userManager.ImportUser(serialization1);

            Assert.Equal(user1.Provider, sameUser1.Provider);
            Assert.Equal(user1.Name, sameUser1.Name);
            Assert.Equal(user1.Key.Hash, sameUser1.Key.Hash);

            // userManager recognizes it as the same user1
            Assert.True(userManager.Validate(sameUser1));

            IPassKeyServices otherHashServices = new PassKeyServices("abc");
            UserManager otherUserManager = new UserManager(otherHashServices);

            // create a similar user
            var otherUser = otherUserManager.Create("git", "fabricio");

            // almost the same characteristics 
            Assert.Equal(user1.Provider, otherUser.Provider);
            Assert.Equal(user1.Name, otherUser.Name);
            // except for the hash
            Assert.NotEqual(user1.Key.Hash, otherUser.Key.Hash);

            Assert.False(userManager.Validate(otherUser));
        }
    }
}
