using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Authentication
{
    internal abstract class Authentication
    {
        public abstract string GetEndpoint();

        readonly string ContentType = "application/json";
    }
}
