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
        public static SpriteBatch spriteBatch;

        public static GameState gameState;
        public static Menu menu;
        public static InGame inGame;
        public static Instructions instructions;
        public static Settings settings;
        public static Lore lore;

        public static SpriteFont font;

        public static Inventory inventory;

        public static int screenWidth = 1183;
        public static int screenHeight = 666;

        bool newClick;
        public static bool newKey;

        Lobby lobby;

        public static MouseState prevMouse;
        public static MouseState mouse;

        KeyboardState prevKb;
        KeyboardState kb;

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

            font = Content.Load<SpriteFont>("Fonts/StatFont");

            inventory = new Inventory(Content, spriteBatch, screenWidth, screenHeight);

            menu = new Menu(Content, spriteBatch, screenWidth, screenHeight);
            inGame = new InGame(Content, spriteBatch, screenWidth, screenHeight);
            instructions = new Instructions(Content, spriteBatch, screenWidth, screenHeight);
            settings = new Settings(Content, spriteBatch, screenWidth, screenHeight);
            lore = new Lore(Content, spriteBatch, screenWidth, screenHeight);

            lobby = new Lobby(Content, spriteBatch, screenWidth, screenHeight);

            menu.LoadContent();
            inGame.LoadContent();
            instructions.LoadContent();
            settings.LoadContent();
            lore.LoadContent();

            gameState = menu;
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
            prevKb = kb;
            kb = Keyboard.GetState();

            newClick = CheckClick(mouse.LeftButton, prevMouse.LeftButton);
            newKey = CheckKey(Keys.Space);

            //if (newClick || newKey)
            //{
                gameState.Update();
            //}
            //else if (gameState == inGame) //? should I do this for updating ingame timer? (timer updates even if user doesn't click)
            //{
            //    //gameState.UpdateTimer(); 
            //}

            base.Update(gameTime);
        }

        //private void UpdateInstr()
        //{
        //    if (CheckClick(mouse.LeftButton, mouse.RightButton, backBttRec))
        //    {
        //        gameState = menu;
        //    }
        //}

        public static bool CheckClick(ButtonState state, ButtonState prevState)
        {
            if (state == ButtonState.Pressed && prevState != ButtonState.Pressed)
            {
                return true;
            }

            return false;
        }

        public static bool CheckHit(Rectangle hitbox)
        {
            if (hitbox.Contains(mouse.Position) && mouse.LeftButton == ButtonState.Pressed && prevMouse.LeftButton!= ButtonState.Pressed)
            {
                return true;
            }

            return false;
        }

        public bool CheckKey(Keys key)
        {
            if (kb.IsKeyDown(key) && !prevKb.IsKeyDown(key))
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

            gameState.Draw(); //migrate legacy code over to displayables/clickables

            List<Clickable> show = gameState.displayables;

            for (int i = 0; i < show.Count(); i++)
            {
                Clickable curr = show[i];
                spriteBatch.Draw(curr.GetImg(), curr.GetHitbox(), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        //private void DrawInstr()
        //{
        //    spriteBatch.DrawString(statFont, "INSTRUCTIONS", testLoc, Color.White);
        //    spriteBatch.Draw(backBttImg, backBttRec, Color.White);
        //}
    }
}
