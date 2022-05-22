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
    public class Settings : SubMenu
    {
        public Settings(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {

        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(bool newClick)
        {
            base.Update(newClick);
        }

        public override void Draw()
        {
            base.Draw();

            spriteBatch.DrawString(statFont, "SETTINGS", testLoc, Color.White);
        }
    }
}
