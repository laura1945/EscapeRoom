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

        public Settings(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
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
            base.Update();

            for (int i = 0; i < buttons.Count(); i++)
            {
                if (Game1.CheckHit(buttons[i].GetHitbox()))
                {
                    buttons[i].Click();
                }
            }
        }

        public override void Draw()
        {
            base.Draw();

            Clickable curButton;

            spriteBatch.DrawString(statFont, "SETTINGS", testLoc, Color.White);

            for (int i = 0; i < buttons.Count(); i++)
            {
                curButton = buttons[i];

                spriteBatch.DrawString(curButton.GetFont(), curButton.GetText(), curButton.GetLoc(), Color.White);
            }
        }
    }
}
