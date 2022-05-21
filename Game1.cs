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

namespace EscapeRoom
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        const int MENU = 0;
        const int INGAME = 1;
        const int INSTRUCTIONS = 2;
        const int SETTINGS = 3;
        const int LORE = 4;
        public static int gameState = MENU;

        const int LOBBY = 0;
        int room = LOBBY;

        int screenWidth = 1183;
        int screenHeight = 666;

        Texture2D backBttImg;
        Texture2D playBttImg;
        Texture2D instrBttImg;
        Texture2D settingsBttImg;
        Texture2D loreBttImg;

        Rectangle playBttRec;
        Rectangle instrBttRec;
        Rectangle settingsBttRec;
        Rectangle loreBttRec;
        Rectangle backBttRec;
        int buttonGap = 65;
        int[] buttonDimen = new int[2];

        Vector2 testLoc = new Vector2(100, 100);

        SpriteFont statFont;

        Lobby lobby;

        public static MouseState prevMouse;
        public static MouseState mouse;

        public static int test = 2; //testing global variable (in Room)

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();

            statFont = Content.Load<SpriteFont>("Fonts/StatFont");

            backBttImg = Content.Load<Texture2D>("Images/Sprites/BackArrow");
            playBttImg = Content.Load<Texture2D>("Images/Sprites/PlayButton");
            instrBttImg = Content.Load<Texture2D>("Images/Sprites/InstrButton");
            settingsBttImg = Content.Load<Texture2D>("Images/Sprites/SettingsButton");
            loreBttImg = Content.Load<Texture2D>("Images/Sprites/LoreButton");

            buttonDimen[0] = playBttImg.Width; 
            buttonDimen[1] = playBttImg.Height;

            backBttRec = new Rectangle(0, screenHeight - backBttImg.Height/3, backBttImg.Width/3, backBttImg.Height/3);
            playBttRec = new Rectangle((screenWidth-buttonDimen[0]) / 2, (int)(screenHeight / 2.5 * 1.5), buttonDimen[0], buttonDimen[1]);
            instrBttRec = new Rectangle(playBttRec.X, playBttRec.Y + buttonGap, buttonDimen[0], buttonDimen[1]);
            settingsBttRec = new Rectangle(playBttRec.X, instrBttRec.Y + buttonGap, buttonDimen[0], buttonDimen[1]);
            loreBttRec = new Rectangle(playBttRec.X, settingsBttRec.Y + buttonGap, buttonDimen[0], buttonDimen[1]);

            lobby = new Lobby(Content, spriteBatch, screenWidth, screenHeight);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            prevMouse = mouse;
            mouse = Mouse.GetState();

            //new_click = CheckClick(ButtonState state, ButtonState prevState, Rectangle rec)
            //gameState.Update()
            switch (gameState)
            {
                case MENU:
                    UpdateMenu();
                    break;

                case INGAME:
                    UpdateGame();
                    break;

                case INSTRUCTIONS:
                    UpdateInstr();
                    break;

                case SETTINGS:
                    UpdateSettings();
                    break;

                case LORE:
                    UpdateLore();
                    break;
            }
            

            base.Update(gameTime);
        }

        private void UpdateMenu()
        {
            if (CheckClick(mouse.LeftButton, prevMouse.LeftButton, playBttRec))
            {
                gameState = INGAME;
            }
            else if (CheckClick(mouse.LeftButton, prevMouse.LeftButton, instrBttRec))
            {
                gameState = INSTRUCTIONS;
            }
            else if (CheckClick(mouse.LeftButton, prevMouse.LeftButton, settingsBttRec))
            {
                gameState = SETTINGS;
            }
            else if (CheckClick(mouse.LeftButton, prevMouse.LeftButton, loreBttRec))
            {
                gameState = LORE;
            }
        }

        private void UpdateGame()
        {
            //if (CheckClick(mouse.LeftButton, mouse.RightButton, backBttRec))
            //{
            //    gameState = MENU;
            //}

            switch (room)
            {
                case LOBBY:
                    lobby.UpdateLobby();
                    break;
            }

        }

        private void UpdateInstr()
        {
            if (CheckClick(mouse.LeftButton, mouse.RightButton, backBttRec))
            {
                gameState = MENU;
            }
        }

        private void UpdateSettings()
        {
            if (CheckClick(mouse.LeftButton, mouse.RightButton, backBttRec))
            {
                gameState = MENU;
            }
        }

        private void UpdateLore()
        {
            if (CheckClick(mouse.LeftButton, mouse.RightButton, backBttRec))
            {
                gameState = MENU;
            }
        }

        private bool CheckClick(ButtonState state, ButtonState prevState, Rectangle rec)
        {
            if (state == ButtonState.Pressed && prevState != ButtonState.Pressed && rec.Contains(mouse.Position))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            switch (gameState)
            {
                case MENU:
                    DrawMenu();
                    break;

                case INGAME:
                    DrawGame();
                    break;

                case INSTRUCTIONS:
                    DrawInstr();
                    break;

                case SETTINGS:
                    DrawSettings();
                    break;

                case LORE:
                    DrawLore();
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawMenu()
        {
            spriteBatch.Draw(playBttImg, playBttRec, Color.White);
            spriteBatch.Draw(instrBttImg, instrBttRec, Color.White);
            spriteBatch.Draw(settingsBttImg, settingsBttRec, Color.White);
            spriteBatch.Draw(loreBttImg, loreBttRec, Color.White);
        }

        private void DrawGame()
        {
            switch (room)
            {
                case LOBBY:
                    lobby.DrawRoom();
                    break;
            }

            //spriteBatch.DrawString(statFont, "INGAME", testLoc, Color.White);
            //spriteBatch.Draw(backBttImg, backBttRec, Color.White);
        }

        private void DrawInstr()
        {
            spriteBatch.DrawString(statFont, "INSTRUCTIONS", testLoc, Color.White);
            spriteBatch.Draw(backBttImg, backBttRec, Color.White);
        }

        private void DrawSettings()
        {
            spriteBatch.DrawString(statFont, "SETTINGS", testLoc, Color.White);
            spriteBatch.Draw(backBttImg, backBttRec, Color.White);
        }

        private void DrawLore()
        {
            spriteBatch.DrawString(statFont, "LORE", testLoc, Color.White);
            spriteBatch.Draw(backBttImg, backBttRec, Color.White);
        }
    }
}
