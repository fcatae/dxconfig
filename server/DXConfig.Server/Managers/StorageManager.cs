﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Models;
using DXConfig.Server.Services;

namespace DXConfig.Server.Managers
{
    public class StorageManager : IStorageManager
    {
        IStoreServices _store;

        // manages user authorization (permissions)
        // encrypt IData at rest
        public StorageManager()
        {
            _store = new MemoryDataStore();
        }

        public IData Read(string container, IPassKey key)
        {
            return _store.ReadData(container);
        }

        public void Write(string container, IData data, IPassKey key)
        {
            _store.WriteData(container, data);
        }
    }
}
