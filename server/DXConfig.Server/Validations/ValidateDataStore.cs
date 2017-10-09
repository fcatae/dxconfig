using DXConfig.Server.Models;
using DXConfig.Server.Services;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server.Validations
{
    public class ValidateDataStore
    {
        public void Validate()
        {
            var store = FileDataStore.Create("tmp/t1");

            store.WriteData("abc.txt", new StringData("123"));

            store.ReadData("abc.txt");

            // read a file that does not exist
            store.ReadData("filedoesnotexist.txt");

            // overwrite the file
            store.WriteData("repeat.txt", new StringData("1"));
            store.WriteData("repeat.txt", new StringData("2"));
            store.WriteData("repeat.txt", new StringData("3"));
        }
    }
}
