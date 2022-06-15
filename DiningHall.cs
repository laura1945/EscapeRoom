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
    public class DiningHall : Room
    {
        //private Texture2D 

        public DiningHall(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Lobby", Content, spriteBatch, screenWidth, screenHeight)
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/DiningHall");
            base.LoadContent();
        }
    }
}
