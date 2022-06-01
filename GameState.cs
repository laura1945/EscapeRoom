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

        public List<Clickable> displayables;
        public List<Clickable> clickables;

        protected SpriteFont statFont;

        protected Vector2 testLoc = new Vector2(100, 100);

        protected Texture2D backBttImg;
        protected Rectangle backBttRec;

        protected Clickable backBtt;

        public GameState(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            this.Content = Content;
            this.spriteBatch = spriteBatch;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            clickables = new List<Clickable>();
            displayables = new List<Clickable>();

            statFont = Content.Load<SpriteFont>("Fonts/StatFont");
        }

        public virtual void LoadContent()
        {
            backBttImg = Content.Load<Texture2D>("Images/Sprites/BackArrow");

            //backBtt = new Clickable(10, screenHeight - backBttImg.Height / 4, backBttImg.Width / 4, backBttImg.Height / 4, backBttImg);

            //clickables.Add(backBtt);
            //displayables.Add(backBtt);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }
    }
}
