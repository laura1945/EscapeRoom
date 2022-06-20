// Author: Laura Zhan
// File Name: SubMenu.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages general data in sub menu game states

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
        //stores title of submenu
        protected Clickable title;
        protected string titleTxt;

        public SubMenu(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight, string titleTxt) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            //set text of title
            this.titleTxt = titleTxt;
        }

        //Pre: none
        //Post: none
        //Desc: load generals for submenu
        public override void LoadContent()
        {
            base.LoadContent();
            
            //initialize back button and title clickables
            backBtt = new Clickable(10, screenHeight - backBttImg.Height / 4, backBttImg.Width / 4, backBttImg.Height / 4, backBttImg);
            title = new Clickable(100, 100, titleTxt, Game1.font, Color.White);

            //set left click of back button to go back to menu page
            backBtt.SetClick(ReturnToMenu);

            //add buttons and title to clickables and displayables
            clickables.Add(backBtt);

            displayables.Add(backBtt);
            displayables.Add(title);
        }

        //Pre: none
        //Post: none
        //Desc: sets game state to menu
        private void ReturnToMenu()
        {
            Game1.gameState = Game1.menu;
        }
    }
}
