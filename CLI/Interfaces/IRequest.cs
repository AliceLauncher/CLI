using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Interfaces
{
    internal interface IRequest
    {
        string Endpoint();
        string Payload();
        
    }
}
