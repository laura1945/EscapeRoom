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
    //    protected Texture2D backBttImg;
    //    protected Rectangle backBttRec;

    //    protected Clickable backBtt;
        protected Clickable title;

        protected string titleTxt;

        public SubMenu(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight, string titleTxt) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            this.titleTxt = titleTxt;
        }

        public override void LoadContent()
        {
            base.LoadContent();

            //backBttImg = Content.Load<Texture2D>("Images/Sprites/BackArrow");

            backBtt = new Clickable(10, screenHeight - backBttImg.Height / 4, backBttImg.Width / 4, backBttImg.Height / 4, backBttImg);
            title = new Clickable(100, 100, titleTxt, Game1.font, Color.White);

            backBtt.SetClick(ReturnToMenu);

            clickables.Add(backBtt);

            displayables.Add(backBtt);
            displayables.Add(title);
        }

        private void ReturnToMenu()
        {
            Game1.gameState = Game1.menu;
        }

        public override void Update()
        {

        }

        public override void Draw()
        {

        }
    }
}
