using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DXConfig.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var loader = new Loader();
            loader.Run(args);
        }
    }
}
