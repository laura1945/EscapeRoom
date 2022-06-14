﻿using System;
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
    public class Kitchen : Room
    {
        public Kitchen(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Kitchen", Content, spriteBatch, screenWidth, screenHeight)
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/kitchen");
            base.LoadContent();
        }
    }
}