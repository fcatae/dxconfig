using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DXConfig.Server.Controllers;

namespace DXConfig.Server.Validations
{
    public class ValidateConfigController
    {
        public void Validate()
        {
            var controller = new ConfigController();
            string secrets = controller.Get("myapp001");

            Console.WriteLine($"Secrets for myapp001: {secrets}");
        }
    }
}
