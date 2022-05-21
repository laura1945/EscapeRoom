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
    class Menu : GameState
    {
        private Rectangle playBttRec;
        private Rectangle instrBttRec;
        private Rectangle settingsBttRec;
        private Rectangle loreBttRec;

        Texture2D playBttImg;
        Texture2D instrBttImg;
        Texture2D settingsBttImg;
        Texture2D loreBttImg;

        int[] buttonDimen = new int[2];
        int buttonGap = 65;

        public Menu(ContentManager Content) : base(Content)
        {
            LoadContent();
        }

        public void LoadContent()
        {
            playBttImg = Content.Load<Texture2D>("Images/Sprites/PlayButton");
            instrBttImg = Content.Load<Texture2D>("Images/Sprites/InstrButton");
            settingsBttImg = Content.Load<Texture2D>("Images/Sprites/SettingsButton");
            loreBttImg = Content.Load<Texture2D>("Images/Sprites/LoreButton");

            buttonDimen[0] = playBttImg.Width;
            buttonDimen[1] = playBttImg.Height;

            playBttRec = new Rectangle((Game1.screenWidth - buttonDimen[0]) / 2, (int)(Game1.screenHeight / 2.5 * 1.5), buttonDimen[0], buttonDimen[1]);
            instrBttRec = new Rectangle(playBttRec.X, playBttRec.Y + buttonGap, buttonDimen[0], buttonDimen[1]);
            settingsBttRec = new Rectangle(playBttRec.X, instrBttRec.Y + buttonGap, buttonDimen[0], buttonDimen[1]);
            loreBttRec = new Rectangle(playBttRec.X, settingsBttRec.Y + buttonGap, buttonDimen[0], buttonDimen[1]);
        }

        public override void Update(bool newClick)
        {
            if (newClick)
            {
                if (Game1.CheckHit(playBttRec))
                {
                    Game1.gameState = Game1.inGame;
                    //Console.WriteLine("INGAME");
                }
                //else if (Game1.CheckHit(instrBttRec))
                //{
                //    Game1.gameState = INSTRUCTIONS;
                //}
                //else if (Game1.CheckHit(settingsBttRec))
                //{
                //    Game1.gameState = SETTINGS;
                //}
                //else if (Game1.CheckHit(loreBttRec))
                //{
                //    Game1.gameState = LORE;
                //}
            }

        }

        public override void Draw()
        {
            Game1.spriteBatch.Draw(playBttImg, playBttRec, Color.White);
            Game1.spriteBatch.Draw(instrBttImg, instrBttRec, Color.White);
            Game1.spriteBatch.Draw(settingsBttImg, settingsBttRec, Color.White);
            Game1.spriteBatch.Draw(loreBttImg, loreBttRec, Color.White);
        }
    }
}
