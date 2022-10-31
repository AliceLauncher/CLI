using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Authentication.Mojang
{
    internal class Mojang : Authentication
    {
        public override string GetEndpoint()
        {
            return "https://authserver.mojang.com";
        }
    }
}
