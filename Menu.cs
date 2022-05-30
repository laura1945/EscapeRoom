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
        private Rectangle playBttRec;
        private Rectangle instrBttRec;
        private Rectangle settingsBttRec;
        private Rectangle loreBttRec;

        Texture2D playBttImg;
        Texture2D instrBttImg;
        Texture2D settingsBttImg;
        Texture2D loreBttImg;

        int[] buttonDimen = new int[2];
        int buttonGap;

        private Clickable playBtt;
        private Clickable instrBtt;
        private Clickable settingsBtt;
        private Clickable loreBtt;

        public Menu(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            buttonGap = 65;
        }

        public override void LoadContent()
        {
            base.LoadContent();

            playBttImg = Content.Load<Texture2D>("Images/Sprites/PlayButton");
            instrBttImg = Content.Load<Texture2D>("Images/Sprites/InstrButton");
            settingsBttImg = Content.Load<Texture2D>("Images/Sprites/SettingsButton");
            loreBttImg = Content.Load<Texture2D>("Images/Sprites/LoreButton");

            buttonDimen[0] = playBttImg.Width;
            buttonDimen[1] = playBttImg.Height;

            //playBttRec = new Rectangle((Game1.screenWidth - buttonDimen[0]) / 2, (int)(Game1.screenHeight / 2.5 * 1.5), buttonDimen[0], buttonDimen[1]);
            //instrBttRec = new Rectangle(playBttRec.X, playBttRec.Y + buttonGap, buttonDimen[0], buttonDimen[1]);
            //settingsBttRec = new Rectangle(playBttRec.X, instrBttRec.Y + buttonGap, buttonDimen[0], buttonDimen[1]);
            //loreBttRec = new Rectangle(playBttRec.X, settingsBttRec.Y + buttonGap, buttonDimen[0], buttonDimen[1]);

            //clickables
            playBtt = new Clickable((Game1.screenWidth - buttonDimen[0]) / 2, (int)(Game1.screenHeight / 2.5 * 1.5), buttonDimen[0], buttonDimen[1], playBttImg);
            instrBtt = new Clickable(playBtt.X(), playBtt.Y() + buttonGap, buttonDimen[0], buttonDimen[1], instrBttImg);
            settingsBtt = new Clickable(playBtt.X(), instrBtt.Y() + buttonGap, buttonDimen[0], buttonDimen[1], settingsBttImg);
            loreBtt = new Clickable(playBtt.X(), settingsBtt.Y() + buttonGap, buttonDimen[0], buttonDimen[1], loreBttImg);

            playBtt.SetClick(StartGame);
            instrBtt.SetClick(ShowInstructions);
            settingsBtt.SetClick(ShowSettings);
            loreBtt.SetClick(ShowLore);

            clickables.Add(playBtt);
            clickables.Add(instrBtt);
            clickables.Add(settingsBtt);
            clickables.Add(loreBtt);

            displayables.Add(playBtt);
            displayables.Add(instrBtt);
            displayables.Add(settingsBtt);
            displayables.Add(loreBtt);
        }

        private void StartGame()
        {
            Game1.gameState = Game1.inGame;
            Game1.inGame.StartNormal();
        }

        private void ShowInstructions()
        {
            Game1.gameState = Game1.instructions;
        }

        private void ShowSettings()
        {
            Game1.gameState = Game1.settings;
        }

        private void ShowLore()
        {
            Game1.gameState = Game1.lore;
        }

        public override void Update()
        {
            //if (Game1.CheckHit(playBttRec))
            //{
            //    Game1.gameState = Game1.inGame;
            //}
            //else if (Game1.CheckHit(instrBttRec))
            //{
            //    Game1.gameState = Game1.instructions;
            //}
            //else if (Game1.CheckHit(settingsBttRec))
            //{
            //    Game1.gameState = Game1.settings;
            //}
            //else if (Game1.CheckHit(loreBttRec))
            //{
            //    Game1.gameState = Game1.lore;
            //}
        }

        public override void Draw()
        {
            //Game1.spriteBatch.Draw(playBttImg, playBttRec, Color.White);
            //Game1.spriteBatch.Draw(instrBttImg, instrBttRec, Color.White);
            //Game1.spriteBatch.Draw(settingsBttImg, settingsBttRec, Color.White);
            //Game1.spriteBatch.Draw(loreBttImg, loreBttRec, Color.White);
        }
    }
}
