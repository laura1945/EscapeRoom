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
    public class SubMenu : GameState
    {
        protected Texture2D backBttImg;
        protected Rectangle backBttRec;

        public SubMenu(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {

        }

        public override void LoadContent()
        {
            base.LoadContent();

            backBttImg = Content.Load<Texture2D>("Images/Sprites/BackArrow");

            backBttRec = new Rectangle(10, screenHeight - backBttImg.Height/4, backBttImg.Width/4, backBttImg.Height/4);
        }

        public override void Update()
        {
            base.Update();
            
            if (Game1.CheckHit(backBttRec))
            {
                Game1.gameState = Game1.menu;
            }
            
        }

        public override void Draw()
        {
            spriteBatch.Draw(backBttImg, backBttRec, Color.White);
        }
    }
}
