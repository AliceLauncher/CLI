using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Authentication.Mojang
{
    /// <summary>
    /// https://wiki.vg/Authentication#Authenticate
    /// </summary>
    internal class Mojang : Authentication
    {
        public override string GetEndpoint()
        {
            return "https://authserver.mojang.com";
        }
    }
}
