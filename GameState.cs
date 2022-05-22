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
    public class GameState
    {
        protected ContentManager Content;
        protected SpriteBatch spriteBatch;
        protected int screenWidth;
        protected int screenHeight;

        protected SpriteFont statFont;

        protected Vector2 testLoc = new Vector2(100, 100);

        public GameState(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            this.Content = Content;
            this.spriteBatch = spriteBatch;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            statFont = statFont = Content.Load<SpriteFont>("Fonts/StatFont");
        }

        public virtual void LoadContent()
        {

        }

        public virtual void Update(bool newClick)
        {

        }

        public virtual void Draw()
        {

        }
    }
}
