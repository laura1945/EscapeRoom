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
    public class Instructions : SubMenu
    {

        public Instructions(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight, string titleTxt) : base(Content, spriteBatch, screenWidth, screenHeight, titleTxt)
        {
            
        }

        public override void LoadContent()
        {
            base.LoadContent();


        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            
        }
    }
}
