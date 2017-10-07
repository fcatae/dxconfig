using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DXConfig.Server.Models;
using DXConfig.Server.Services;
using Xunit;

namespace Test.Server
{
    public class HashKeyServicesTest
    {
        [Fact]
        public void TestHashes()
        {
            IPassKeyServices hashServices1 = new PassKeyServices("abc");
            IPassKeyServices otherHashServices = new PassKeyServices("123");

            var hash1 = hashServices1.CreateKey("abc") as HashKey;
            var hash2 = hashServices1.CreateKey("abc") as HashKey;
            var hash3 = hashServices1.CreateKey("123");

            var otherHash = otherHashServices.CreateKey("abc") as HashKey;

            Assert.True(hash1.Value.Length == 3);
            Assert.True(hash1.Hash.Length > 3);

            Assert.True(hashServices1.ValidateKey(hash1));
            Assert.True(hashServices1.ValidateKey(hash2));
            Assert.True(hashServices1.ValidateKey(hash3));

            Assert.True(otherHashServices.ValidateKey(otherHash));

            Assert.False(hashServices1.ValidateKey(otherHash));
            Assert.False(otherHashServices.ValidateKey(hash1));

            Assert.Equal(hash1.Hash, hash2.Hash);

            Assert.NotEqual(hash1.Hash, otherHash.Hash);
        }

        [Fact]
        public void TestImportExport()
        {
            IPassKeyServices hashServices1 = new PassKeyServices("abc");
            IPassKeyServices otherHashServices = new PassKeyServices("123");

            var hash1 = hashServices1.CreateKey("abc") as HashKey;
            var hash2 = hashServices1.CreateKey("abc") as HashKey;
        }
    }
}
