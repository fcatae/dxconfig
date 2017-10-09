using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Validations;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DXConfig.Server
{
    public class Loader
    {
        public void Run(string[] args)
        {
            PreValidation();

            var host = BuildWebHost(args);
            
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .Build();
        }

        public void PreValidation()
        {
#if DEBUG
            ValidateConfigController configController = new ValidateConfigController();
            configController.Validate();

            var validateDataStore = new ValidateDataStore();
            validateDataStore.Validate();
#endif
        }
    }
}
