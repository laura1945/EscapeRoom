// Author: Laura Zhan
// File Name: Settings.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages the settings page

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
    public class Settings : SubMenu
    {
        //mute button
        private Toggle muteButton;

        private Texture2D musicOnImg;
        private Texture2D musicOffImg;

        public Settings(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight, string titleTxt) : base(Content, spriteBatch, screenWidth, screenHeight, titleTxt)
        {
            
        }

        //Pre: none
        //Post: none
        //Desc: load sub menu's data
        public override void LoadContent()
        {
            base.LoadContent();

            musicOnImg = Content.Load<Texture2D>("Images/Sprites/SoundOn");
            musicOffImg = Content.Load<Texture2D>("Images/Sprites/SoundOff");

            //set up mute button
            muteButton = new Toggle(300, 300, 50, 50, musicOnImg, musicOffImg);
            muteButton.SetClick(SwitchState);

            //add mute button to displayables
            displayables.Add(muteButton);
        }

        //Pre: none
        //Post: none
        //Desc: switch on off state
        private void SwitchState()
        {
            if (muteButton.GetOnState())
            {
                muteButton.SetOnState(false);
                MediaPlayer.Pause();
            }
            else
            {
                muteButton.SetOnState(true);
                MediaPlayer.Resume();
            }

            displayables.Clear();
            displayables.Add(muteButton);
        }
    }
}
