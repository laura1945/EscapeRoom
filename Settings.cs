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
        //list of buttons
        private List<Clickable> buttons;

        //mute button
        private Toggle muteButton;

        public Settings(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight, string titleTxt) : base(Content, spriteBatch, screenWidth, screenHeight, titleTxt)
        {
            //set up buttons
            buttons = new List<Clickable>();

            muteButton = new Toggle(300, 300, 50, 50);
            muteButton.SetText("Mute");
            muteButton.SetOffText("Unmute");

            muteButton.SetOnState(false);

            //add mute button to list
            buttons.Add(muteButton);
        }

        //Pre: none
        //Post: none
        //Desc: load sub menu's data
        public override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
