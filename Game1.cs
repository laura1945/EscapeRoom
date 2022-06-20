// Author: Laura Zhan
// File Name: Game1.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This is the main class of the game that adds Clickables and Displayables on the screen

/*Course Concepts:
- Lists used to store keys, collectables, and room connections
- OOP: each room is an object with its own data, items and clickables are objects, game states are objects, and there's inheritance, such as Key is a child of Item
- Stacks used to control only one item is interactable at a time in a room
- Linked structure is used to manage each room's connection to other rooms 
- File IO used to save game data such as items, collectables, and keys in inventory
*/

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
        //used to draw images and strings
        private GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;

        //Initializes variables for reading and writing to files
        private static StreamReader inFile = null;
        private static StreamWriter outFile = null;
        private static string statsFileName = "stats.txt";
        private static char splitChar = ',';

        //game states
        public static GameState gameState;
        public static Menu menu;
        public static InGame inGame;
        public static Instructions instructions;
        public static Settings settings;
        public static Lore lore;

        //font types
        public static SpriteFont font;
        public static SpriteFont labelFont;

        //instance of inventory to store user's collected items
        public static Inventory inventory;

        //key to lobby
        private Key lobbyKey;

        //screen width and height
        public static int screenWidth = 1183;
        public static int screenHeight = 666;

        //The different room types
        public static Lobby lobby;
        public static Ballroom ballroom;
        public static DiningHall diningHall;
        public static Bedroom1 bedroom1;
        public static Bedroom2 bedroom2;
        public static Kitchen kitchen;
        public static Lab lab;
        public static Attic attic;
        public static Library library;
        public static MusicRoom musicRoom;
        private List<Room> rooms;

        //stores previous and current state of mouse
        public static MouseState prevMouse;
        public static MouseState mouse;

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

            //makes mouse visible on screen
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

            //set screen dimensions
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();

            //load fonts
            font = Content.Load<SpriteFont>("Fonts/StatFont");
            labelFont = Content.Load<SpriteFont>("Fonts/LabelFont");

            //create instance of Inventory
            inventory = new Inventory(Content, spriteBatch, screenWidth, screenHeight);

            //create instances of different rooms
            lobby = new Lobby(Content, spriteBatch, screenWidth, screenHeight);
            ballroom = new Ballroom(Content, spriteBatch, screenWidth, screenHeight);
            diningHall = new DiningHall(Content, spriteBatch, screenWidth, screenHeight);
            bedroom1 = new Bedroom1(Content, spriteBatch, screenWidth, screenHeight);
            bedroom2 = new Bedroom2(Content, spriteBatch, screenWidth, screenHeight);
            kitchen = new Kitchen(Content, spriteBatch, screenWidth, screenHeight);
            lab = new Lab(Content, spriteBatch, screenWidth, screenHeight);
            attic = new Attic(Content, spriteBatch, screenWidth, screenHeight);
            library = new Library(Content, spriteBatch, screenWidth, screenHeight);
            musicRoom = new MusicRoom(Content, spriteBatch, screenWidth, screenHeight);

            //add rooms to the list of rooms
            rooms = new List<Room>();
            rooms.Add(lobby);
            rooms.Add(ballroom);
            rooms.Add(diningHall);
            rooms.Add(bedroom1);
            rooms.Add(bedroom2);
            rooms.Add(kitchen);
            rooms.Add(lab);
            rooms.Add(attic);
            rooms.Add(library);
            rooms.Add(musicRoom);

            //run for the number of rooms in the list
            for (int i = 0; i < rooms.Count(); i++)
            {
                //load each room's data
                rooms[i].LoadContent();
            }

            //initialize each game state
            menu = new Menu(Content, spriteBatch, screenWidth, screenHeight);
            inGame = new InGame(Content, spriteBatch, screenWidth, screenHeight);
            instructions = new Instructions(Content, spriteBatch, screenWidth, screenHeight, "Instructions");
            settings = new Settings(Content, spriteBatch, screenWidth, screenHeight, "Settings");
            lore = new Lore(Content, spriteBatch, screenWidth, screenHeight, "Back story");

            //Set room connections
            lobby.SetConnection(ballroom, "right");
            lobby.SetConnection(diningHall, "left");

            ballroom.SetConnection(bedroom1, "front");
            ballroom.SetConnection(kitchen, "left");
            ballroom.SetConnection(lobby, "back");

            kitchen.SetConnection(ballroom, "right");
            kitchen.SetConnection(diningHall, "left");

            diningHall.SetConnection(kitchen, "right");
            diningHall.SetConnection(lab, "left");
            diningHall.SetConnection(lobby, "back");
            diningHall.SetConnection(bedroom2, "front");

            lab.SetConnection(diningHall, "right");
            attic.SetConnection(bedroom1, "left");

            bedroom1.SetConnection(attic, "right");
            bedroom1.SetConnection(bedroom2, "left");
            bedroom1.SetConnection(ballroom, "back");

            bedroom2.SetConnection(bedroom1, "right");
            bedroom2.SetConnection(diningHall, "back");
            bedroom2.SetConnection(library, "front");

            library.SetConnection(bedroom2, "back");
            library.SetConnection(musicRoom, "front");

            musicRoom.SetConnection(library, "back");

            //load each game state's content
            menu.LoadContent();
            inGame.LoadContent();
            instructions.LoadContent();
            settings.LoadContent();
            lore.LoadContent();

            //initialize lobby key 
            lobbyKey = new Key(lobby.lobbyKeyDesc[0], lobby.keyImg, lobby.lobbyKeyDesc[1], lobby);

            //associate key item with a clickable
            lobbyKey.SetClickable(new Clickable(50, 200, lobby.keyImg.Width / 12, lobby.keyImg.Height / 12, lobby.keyImg));

            //add key to inventory
            inventory.AddKey(lobbyKey);

            //set gamestate to menu
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

            //track previous mouse state and retrieve new mouse state
            prevMouse = mouse;
            mouse = Mouse.GetState();

            //store the current gamestate's clickables
            List<Clickable> clickables = gameState.clickables;

            //run for number of clickables
            for (int i = 0; i < gameState.clickables.Count(); i++)
            {
                //check if user left or right clicked on a clickable
                if (CheckHit(gameState.clickables[i].GetHitbox()))
                {
                    //run associated function with left click on that clickable
                    gameState.clickables[i].Click();
                    break;
                }
                else if (CheckRightClick(gameState.clickables[i].GetHitbox()))
                {
                    //run associated function with right click on that clickable
                    gameState.clickables[i].RightClick();
                    break;
                }
            }

            base.Update(gameTime);
        }

        //Pre: hitbox is a rectangle that represents the hitbox of a button/clickable
        //Post: returns true if left clicked on, false otherwise
        //Description: checks if user left clicked on something
        public static bool CheckHit(Rectangle hitbox)
        {
            //checks if user left clicked on something and previous mouse state is not pressed
            if (hitbox.Contains(mouse.Position) && mouse.LeftButton == ButtonState.Pressed && prevMouse.LeftButton!= ButtonState.Pressed)
            {
                //return true
                return true;
            }

            //return false (if not clicked on)
            return false;
        }

        //Pre: hitbox is a rectangle that represents the hitbox of a button/clickable
        //Post: returns true if right clicked on, false otherwise
        //Description: checks if user right clicked on something
        public static bool CheckRightClick(Rectangle hitbox)
        {
            //checks if user right clicked on something and previous mouse state is not pressed
            if (hitbox.Contains(mouse.Position) && mouse.RightButton == ButtonState.Pressed && prevMouse.RightButton != ButtonState.Pressed)
            {
                //return true
                return true;
            }

            //return false
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

            //begins a new sprite and text batch
            spriteBatch.Begin();

            //store list of things to display from a game state
            List<Clickable> show = gameState.displayables;

            //run for the number of displayables in show list
            for (int i = 0; i < show.Count(); i++)
            {
                //store durrent displayable
                Clickable curr = show[i];

                //run if displayable is not empty
                if (curr != null)
                {
                    //checks if displayable's image is empty
                    if (curr.GetImg() != null)
                    {
                        //draw image
                        spriteBatch.Draw(curr.GetImg(), curr.GetHitbox(), Color.White);
                    }

                    //checks if displayable's text is empty
                    if (curr.GetText() != null)
                    {
                        //draw text
                        spriteBatch.DrawString(curr.GetFont(), curr.GetText(), curr.GetLoc(), curr.GetColour());
                    }
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        //Pre: none
        //Post: none
        //Description: saves in-game data
        private void SaveGame()
        {
            //store lists from inventory
            List<Item> items = inventory.items;
            List<Item> collectables = inventory.collectables;
            List<Key> keys = inventory.keys;

            //attempt the following actions
            try
            {
                //Opens and overwrites existing file or creates it if it doesn't already exist
                outFile = File.CreateText(statsFileName);

                //write data

                //current room
                outFile.WriteLine(inGame.room);

                //save inventory
                WriteItemList(items);
                outFile.WriteLine();
                WriteItemList(collectables);
                outFile.WriteLine();
                WriteKeyList(keys);
            }
            catch (IndexOutOfRangeException re)
            {
                //outputs out of range error
                Console.WriteLine("ERROR: " + re.Message);
            }
            catch (Exception e)
            {
                //outputs general error message
                Console.WriteLine("ERROR: " + e.Message);
            }
            finally
            {
                //close file if it's not empty
                if (outFile != null)
                {
                    outFile.Close();
                }
            }
        }

        //Pre: items is a list of existing items
        //Post: none
        //Description: writes out all items to file
        private void WriteItemList(List<Item> items)
        {
            //run for number of items
            for (int i = 0; i < items.Count(); i++)
            {
                //write item name
                outFile.Write(items[i].GetName());

                //separate items by comma
                if (i < items.Count() - 1)
                {
                    outFile.Write(splitChar);
                }
            }
        }

        //Pre: keys is a list of existing items
        //Post: none
        //Description: writes out all keys to file
        private void WriteKeyList(List<Key> keys)
        {
            //run for number of keys
            for (int i = 0; i < keys.Count(); i++)
            {
                //write key name
                outFile.Write(keys[i].GetName());

                //separate keys by comma
                if (i < keys.Count() - 1)
                {
                    outFile.Write(splitChar);
                }
            }
        }
    }
}
