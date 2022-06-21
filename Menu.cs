// Author: Laura Zhan
// File Name: Menu.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class is the menu game state

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
    public class Menu : GameState
    {
        //hitboxes of buttons
        private Rectangle playBttRec;
        private Rectangle instrBttRec;
        private Rectangle settingsBttRec;
        private Rectangle loreBttRec;

        //button images
        Texture2D playBttImg;
        Texture2D instrBttImg;
        Texture2D settingsBttImg;
        Texture2D loreBttImg;

        //button UI 
        int[] buttonDimen = new int[2];
        int buttonGap;

        //clickables associated with buttons
        private Clickable playBtt;
        private Clickable instrBtt;
        private Clickable settingsBtt;
        private Clickable loreBtt;

        public Menu(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            //set vertical distance between each button
            buttonGap = 65;
        }

        //Pre: none
        //Post: none
        //Desc: load data for menu page
        public override void LoadContent()
        {
            //load general game state data
            base.LoadContent();

            //load button images
            playBttImg = Content.Load<Texture2D>("Images/Sprites/PlayButton");
            instrBttImg = Content.Load<Texture2D>("Images/Sprites/InstrButton");
            settingsBttImg = Content.Load<Texture2D>("Images/Sprites/SettingsButton");
            loreBttImg = Content.Load<Texture2D>("Images/Sprites/LoreButton");

            //set button dimensions
            buttonDimen[0] = playBttImg.Width;
            buttonDimen[1] = playBttImg.Height;

            //initialize clickables 
            playBtt = new Clickable((Game1.screenWidth - buttonDimen[0]) / 2, (int)(Game1.screenHeight / 2.5 * 1.5), buttonDimen[0], buttonDimen[1], playBttImg);
            instrBtt = new Clickable(playBtt.X(), playBtt.Y() + buttonGap, buttonDimen[0], buttonDimen[1], instrBttImg);
            settingsBtt = new Clickable(playBtt.X(), instrBtt.Y() + buttonGap, buttonDimen[0], buttonDimen[1], settingsBttImg);
            loreBtt = new Clickable(playBtt.X(), settingsBtt.Y() + buttonGap, buttonDimen[0], buttonDimen[1], loreBttImg);

            //associate each button with a function
            playBtt.SetClick(StartGame);
            instrBtt.SetClick(ShowInstructions);
            settingsBtt.SetClick(ShowSettings);
            loreBtt.SetClick(ShowLore);

            //add buttons to clickables
            clickables.Add(playBtt);
            clickables.Add(instrBtt);
            clickables.Add(settingsBtt);
            clickables.Add(loreBtt);

            //add buttons displayables
            displayables.Add(playBtt);
            displayables.Add(instrBtt);
            displayables.Add(settingsBtt);
            displayables.Add(loreBtt);
        }

        //Pre: none
        //Post: none
        //Desc: start a game
        private void StartGame()
        {
            //set game state to be in game
            Game1.gameState = Game1.inGame;

            //start normal game state
            Game1.inGame.StartNormal();
        }

        //Pre: none
        //Post: none
        //Desc: set game state to instructions page
        private void ShowInstructions()
        {
            Game1.gameState = Game1.instructions;
        }

        //Pre: none
        //Post: none
        //Desc: set game state to settings page
        private void ShowSettings()
        {
            Game1.gameState = Game1.settings;
        }

        //Pre: none
        //Post: none
        //Desc: set game state to lore page
        private void ShowLore()
        {
            Game1.gameState = Game1.lore;
        }
    }
}
