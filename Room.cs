using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

namespace EscapeRoom
{
    class Room
    {
        protected string name;

        //private List<Room> connections;
        protected Room back;
        protected Room front;
        protected Room right;
        protected Room left;

        protected ItemStack itemStack;
        protected Item collectable;

        public Room(string name)
        {
            this.name = name;
        }
        
        public void SetConnection(Room connectedRoom, string direction)
        {
            switch (direction)
            {
                case "back":
                    back = connectedRoom;
                    break;

                case "front":
                    front = connectedRoom;
                    break;

                case "right":
                    right = connectedRoom;
                    break;

                case "left":
                    left = connectedRoom;
                    break;
            }
        }

        //public void AddImage()
    }
}
