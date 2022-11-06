using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
/*            foreach (var item in game.arguments.jvm)
            {
                if(item is string)
                {
                    args += item;
                }
                if(item is ArgumentsRules)
                {
                    var rules = (ArgumentsRules)item;
                    
                }
            }
            foreach (var item in game.arguments.game)
            {
                if (item is string)
                {
                    args += item;
                }
                if (item is ArgumentsRules)
                {
                    var rules = (ArgumentsRules)item;

                }
            }*/
        }

        public string GetArguments()
        {
            return args;
        }

        public string AddArguments(string arg) => args += arg;
    }
}
