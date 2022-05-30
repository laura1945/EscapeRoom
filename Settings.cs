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
        private List<Clickable> buttons;

        private Toggle muteButton;

        public Settings(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight, string titleTxt) : base(Content, spriteBatch, screenWidth, screenHeight, titleTxt)
        {
            buttons = new List<Clickable>();

            muteButton = new Toggle(300, 300, 50, 50);
            muteButton.SetText("Mute", statFont);
            muteButton.SetOffText("Unmute");

            muteButton.SetOnState(false);

            buttons.Add(muteButton);
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update()
        {
            
        }

        public override void Draw()
        {

        }
    }
}
