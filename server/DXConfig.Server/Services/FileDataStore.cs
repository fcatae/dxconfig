using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;
using System.IO;
using System.Text;
using System.Net;

namespace DXConfig.Server.Services
{
    public class FileDataStore : IStoreServices
    {
        private string _rootFolderName;
        
        protected FileDataStore(string fullpath)
        {
            var directoryInfo = new DirectoryInfo(fullpath);

            _rootFolderName = directoryInfo.FullName;
        }

        public static FileDataStore Create(string path)
        {
            var store = new FileDataStore(path);

            store.CreateIfNotExists();

            return store;
        }

        private void CreateIfNotExists()
        {
            var directory = new DirectoryInfo(_rootFolderName);

            if (!directory.Exists)
            {
                directory.Create();
            }
        }

        string GetFilename(string containerName)
        {
            // escape the current name
            string filename = WebUtility.UrlEncode(containerName);

            // append to the store root folder
            string absoluteFilename = Path.Combine(_rootFolderName, filename);

            return absoluteFilename;
        }

        public IData ReadData(string containerName)
        {
            try
            {
                string filename = GetFilename(containerName);
                string content = File.ReadAllText(filename);

                return new StringData(content);
            }
            catch (FileNotFoundException)
            { }

            return null;
        }

        public void WriteData(string containerName, IData containerData)
        {
            string filename = GetFilename(containerName);
            string content = containerData.ToString();

            File.WriteAllText(filename, content);
        }
    }
}
