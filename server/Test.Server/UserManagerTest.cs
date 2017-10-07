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
            HashKeyServices hashServices = new HashKeyServices("123");
            UserManager userManager = new UserManager(hashServices);

            var user1 = userManager.Create("git", "fabricio");

            // serialize
            string serialization1 = user1.ToString();
            
            // deserialize
            var sameUser1 = User.Create(serialization1);

            Assert.Equal(user1.Provider, sameUser1.Provider);
            Assert.Equal(user1.Name, sameUser1.Name);
            Assert.Equal(user1.Hash, sameUser1.Hash);

            // userManager recognizes it as the same user1
            Assert.True(userManager.Validate(sameUser1));
                        
            HashKeyServices otherHashServices = new HashKeyServices("abc");
            UserManager otherUserManager = new UserManager(otherHashServices);

            // create a similar user
            var otherUser = otherUserManager.Create("git", "fabricio");

            // almost the same characteristics 
            Assert.Equal(user1.Provider, otherUser.Provider);
            Assert.Equal(user1.Name, otherUser.Name);
            // except for the hash
            Assert.NotEqual(user1.Hash, otherUser.Hash);

            Assert.False(userManager.Validate(otherUser));
        }
    }
}
