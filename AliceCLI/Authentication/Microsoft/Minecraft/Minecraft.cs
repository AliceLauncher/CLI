using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Authentication.Microsoft.Minecraft
{
    /// <summary>
    /// https://wiki.vg/Microsoft_Authentication_Scheme
    /// </summary>
    internal class Minecraft : Authentication
    {
        public override string GetEndpoint()
        {
            return "https://api.minecraftservices.com/";
        }
    }
}
