using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AliceCLI.Modloader
{
    internal interface IModloader
    {
        string URL();
        JsonSerializer Deserialize();

    }
}
