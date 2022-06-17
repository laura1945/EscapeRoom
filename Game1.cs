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
        public static SpriteFont labelFont;

        public static Inventory inventory;
        private Key lobbyKey;

        public static int screenWidth = 1183;
        public static int screenHeight = 666;

        bool newClick;
        public static bool newKey;

        public static Lobby lobby;
        public static Ballroom ballroom;
        public static DiningHall diningRoom;
        public static Bedroom1 bedroom1;
        public static Bedroom2 bedroom2;
        public static Kitchen kitchen;
        public static Lab lab;
        public static Attic attic;
        public static Library library;
        public static MusicRoom musicRoom;
        private List<Room> rooms;

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
            labelFont = Content.Load<SpriteFont>("Fonts/LabelFont");

            inventory = new Inventory(Content, spriteBatch, screenWidth, screenHeight);

            lobby = new Lobby(Content, spriteBatch, screenWidth, screenHeight);
            ballroom = new Ballroom(Content, spriteBatch, screenWidth, screenHeight);
            diningRoom = new DiningHall(Content, spriteBatch, screenWidth, screenHeight);
            bedroom1 = new Bedroom1(Content, spriteBatch, screenWidth, screenHeight);
            bedroom2 = new Bedroom2(Content, spriteBatch, screenWidth, screenHeight);
            kitchen = new Kitchen(Content, spriteBatch, screenWidth, screenHeight);
            lab = new Lab(Content, spriteBatch, screenWidth, screenHeight);
            attic = new Attic(Content, spriteBatch, screenWidth, screenHeight);
            library = new Library(Content, spriteBatch, screenWidth, screenHeight);
            musicRoom = new MusicRoom(Content, spriteBatch, screenWidth, screenHeight);

            rooms = new List<Room>();
            rooms.Add(lobby);
            rooms.Add(ballroom);
            rooms.Add(diningRoom);
            rooms.Add(bedroom1);
            rooms.Add(bedroom2);
            rooms.Add(kitchen);
            rooms.Add(lab);
            rooms.Add(attic);
            rooms.Add(library);
            rooms.Add(musicRoom);

            for (int i = 0; i < rooms.Count(); i++)
            {
                rooms[i].LoadContent();
            }

            menu = new Menu(Content, spriteBatch, screenWidth, screenHeight);
            inGame = new InGame(Content, spriteBatch, screenWidth, screenHeight);
            instructions = new Instructions(Content, spriteBatch, screenWidth, screenHeight, "Instructions");
            settings = new Settings(Content, spriteBatch, screenWidth, screenHeight, "Settings");
            lore = new Lore(Content, spriteBatch, screenWidth, screenHeight, "Back story");

            lobby.SetConnection(ballroom, "right");
            lobby.SetConnection(diningRoom, "left");
            ballroom.SetConnection(bedroom1, "front");
            ballroom.SetConnection(kitchen, "left");

            menu.LoadContent();
            inGame.LoadContent();
            instructions.LoadContent();
            settings.LoadContent();
            lore.LoadContent();

            lobbyKey = new Key(Content, spriteBatch, screenWidth, screenHeight, lobby.lobbyKeyDesc[0], lobby.keyImg, lobby.lobbyKeyDesc[1], lobby);

            lobbyKey.SetClickable(new Clickable(50, 200, lobby.keyImg.Width / 12, lobby.keyImg.Height / 12, lobby.keyImg));

            inventory.AddKey(lobbyKey);

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

            List<Clickable> clickables = gameState.clickables;
            //Console.WriteLine(clickables.Count());

            if (gameState != inGame && gameState != menu)
            {
                gameState.Update();
            }

            for (int i = 0; i < gameState.clickables.Count(); i++)
            {
                if (Game1.CheckHit(gameState.clickables[i].GetHitbox()))
                {
                    gameState.clickables[i].Click();
                    break;
                }
            }

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

            gameState.Draw();

            List<Clickable> show = gameState.displayables;
            //Console.WriteLine(show.Count());
            //Console.WriteLine(show[0].GetImg());

            for (int i = 0; i < show.Count(); i++)
            {
                Clickable curr = show[i];

                if (curr != null)
                {
                    if (curr.GetImg() != null)
                    {
                        spriteBatch.Draw(curr.GetImg(), curr.GetHitbox(), Color.White);
                    }
                    else
                    {
                        //Console.WriteLine("Image null");
                    }

                    if (curr.GetText() != null)
                    {
                        spriteBatch.DrawString(curr.GetFont(), curr.GetText(), curr.GetLoc(), curr.GetColour());
                    }
                    else
                    {
                        //Console.WriteLine("Text null");
                    }
                }
                
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
