using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliceCLI.Modloader.Vanilla
{
    internal partial class Arguments
    {
        // order JVM -> user arguments -> releases etc

        /// <summary>
        /// windows
        /// linux
        /// osx
        /// </summary>

        string args = "";
        
        // pass os in constr
        public Arguments()
        {

        }

        public string GetArguments()
        {
            return "";
        }

        public string AddArguments(string arg) => args += arg;
    }
}
