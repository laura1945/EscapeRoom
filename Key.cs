// Author: Laura Zhan
// File Name: Key.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class represents a key item

using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Animation2D;
using Helper;
using Microsoft.Xna.Framework.Content;

namespace EscapeRoom
{
    public class Key : Item
    {
        //store room associated with key
        private Room room;

        public Key(string name, Texture2D itemImg, string details, Room room) : base(name, itemImg, details)
        {
            //set room
            this.room = room;
        }

        //Pre: none
        //Post: returns a room
        //Desc: returns room associated with key
        public Room GetRoom()
        {
            return room;
        }
    }
}
