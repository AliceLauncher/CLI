using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Authentication.Microsoft.XSTS
{
    internal class XSTS : Authentication
    {
        public override string GetEndpoint()
        {
            return "https://user.auth.xboxlive.com/";
        }
    }
}
