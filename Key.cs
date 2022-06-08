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
        private Room room;

        public Key(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight, string name, Texture2D itemImg, string details, Room room) : base(Content, spriteBatch, screenWidth, screenHeight, name, itemImg, details)
        {
            this.room = room;
        }

        //Accessors
        public Room GetRoom()
        {
            return room;
        }
    }
}
