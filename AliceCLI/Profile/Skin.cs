using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Profile
{
    internal class Skin
    {
        private string ID { get; set; }
        private bool State { get; set; }
        private string URL { get; set; }
        private Variant Variant { get; set; }
        private Alias Alias { get; set; }
        public Skin(string iD, bool state, string uRL, Variant variant, Alias alias)
        {
            ID = iD;
            State = state;
            URL = uRL;
            Variant = variant;
            Alias = alias;
        }

        public string GetID() => ID;
        public bool GetState() => State;
        public string GetURL() => URL;
        public Variant GetVariant() => Variant;
        public Alias GetAlias() => Alias;
    }
}
