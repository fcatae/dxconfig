using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Infra;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DXConfig.Server.Controllers
{
    [Route("api/[controller]")]
    public class StorageController : Controller
    {
        private readonly IStorageManager _storageManager;
        private readonly IUserAccessHandler _userAccess;

        public StorageController(IStorageManager storageManager, IUserAccessHandler userAccess)
        {
            _storageManager = storageManager;
            _userAccess = userAccess;
        }
        
        // GET api/storage/<container>
        [HttpGet("{container}", Name="Storage_Get")]
        public string Get(string container)
        {
            string container2 = WebUtility.UrlDecode(container);

            var user = _userAccess.GetUser();

            var data = _storageManager.Read(user, container2);
            
            if (data == null)
                return "(null)";

            return data.ToString();
        }

        // POST api/config/myapp001
        [HttpPost("{container}")]
        public void Post([FromRoute]string container, [FromBody]string value)
        {
            var user = _userAccess.GetUser();

            _storageManager.Write(user, container, new StringData(value));            
        }        
    }
}
