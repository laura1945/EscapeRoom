// Author: Laura Zhan
// File Name: Lore.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class is the lore page

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
    public class Lore : SubMenu
    {
        //stores story elements
        private Clickable story;
        private string storyText;

        public Lore(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight, string titleTxt) : base(Content, spriteBatch, screenWidth, screenHeight, titleTxt)
        {
            //set story 
            storyText = "On June 20, 2022, Laura Zhan accepted her fate. She realized that she couldn't finish this project, so the final level in this game is to complete this code. \nGood luck and have fun!"; 

            story = new Clickable(50, 200, storyText, Game1.font, Color.White);
        }

        //Pre: none
        //Post: none
        //Desc: load general sub menu content and add story to displayables list
        public override void LoadContent()
        {
            base.LoadContent();

            displayables.Add(story);
        }
    }
}
