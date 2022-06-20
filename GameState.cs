// Author: Laura Zhan
// File Name: GameState.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages the game states

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
        //variables for loading images and fonts
        protected ContentManager Content;
        protected SpriteBatch spriteBatch;
        protected int screenWidth;
        protected int screenHeight;

        //list of displayables and clickables for a game state
        public List<Clickable> displayables;
        public List<Clickable> clickables;

        //font and location
        protected SpriteFont statFont;

        //back button
        protected Texture2D backBttImg;
        protected Rectangle backBttRec;
        protected Clickable backBtt;

        public GameState(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            //set variables
            this.Content = Content;
            this.spriteBatch = spriteBatch;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            //initialize lists
            clickables = new List<Clickable>();
            displayables = new List<Clickable>();

            //load font 
            statFont = Content.Load<SpriteFont>("Fonts/StatFont");
        }

        //Pre: none
        //Post: none
        //Desc: load general content for game state
        public virtual void LoadContent()
        {
            //load back button image
            backBttImg = Content.Load<Texture2D>("Images/Sprites/BackArrow");
        }
    }
}
