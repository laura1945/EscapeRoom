using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    class Lobby : Room
    {
        private Item collectable;

        public Lobby(Item collectable) : base("Lobby")
        {
            this.collectable = collectable;
        }
    }
}
