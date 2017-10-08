using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Infra;
using DXConfig.Server.Managers;
using DXConfig.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DXConfig.Server.Controllers
{
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        public SessionController()
        {
        }

        [HttpPost("init")]
        public string Init(string clientinfo)
        {
            // 1. Client calls /api/session/init with clientinfo = { hostname, username, (pincode) }
            // 2. Server returns a {session_url, session_token, signed(clientinfo)}
            return null;
        }

        [HttpGet("wait")]
        public bool Wait([FromQuery]string session_id, [FromQuery]string session_hash)
        {
            // 9. Client polls /api/session/wait? session_token
            // 11. Client is notified at /api/session/wait of successful auth
            return true;

            // how to protect from brute force?
            // may use session_hash to check it first?
        }

        [HttpPost("complete")]
        public void Complete([FromQuery]string session_id, string userpasskey)
        {
            // callback: complete
            // 10. Session API receives the Github token at /api/session/complete(auth?)

            // store the oauth locally

            // how to prevent from attack?
            // validate userpasskey?
        }

        [HttpGet("retrieve")]
        public string Retrieve(string clientinfo)
        {
            // 12. Client downloads IPassKey at /api/session/retrieve with clientinfo
            return null;
        }        
    }
}