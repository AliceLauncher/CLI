using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Profile
{
    internal class Player
    {
        private string? ID { get; set; }
        private string? Name { get; set; }
        private Skin[]? Skins { get; set; }
        private string[]? Capes { get; set; }

        public Player(string? iD, string? name, Skin[]? skins, string[]? capes)
        {
            ID = iD;
            Name = name;
            Skins = skins;
            Capes = capes;
        }

        public string GetID() => ID;
        public string GetName() => Name;
        public Skin[] GetSkins() => Skins;
        public string GetCapes() => Capes;

    }
}
