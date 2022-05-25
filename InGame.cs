using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    public class InGame : GameState
    {
        private Room room;
        private Lobby lobby;

        public const int NORMAL = 0;
        public const int INVENTORY = 1;
        public const int POPUP = 2;
        public int inGameState;
        

        private List<Clickable> clickables;

        public InGame(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            lobby = new Lobby(Content, spriteBatch, screenWidth, screenHeight);
            room = lobby;
            inGameState = NORMAL;

            clickables = new List<Clickable>();
        }

        public override void LoadContent()
        {
            base.LoadContent();

            lobby.LoadContent();
            clickables.Add(room.GetClickable());
        }

        public override void Update()
        {
            clickables.Clear();

            Console.WriteLine("inGameState: " + inGameState);

            switch (inGameState)
            {
                case NORMAL:
                    
                    clickables.Add(room.GetClickable());
                    //Console.WriteLine("clickables count: " + clickables.Count());
                    //loop through clickables, if matches hitbox, change state to POPUP
                    if (room.GetClickable() != null)
                    {
                        for (int i = 0; i < clickables.Count(); i++)
                        {
                            if (Game1.CheckHit(clickables[i].GetHitbox()))
                            {
                                Game1.inventory.AddItem(room.GetItemStack().Pop());
                                inGameState = POPUP;
                            }
                        }
                    }

                    if (Game1.newKey)
                    {
                        inGameState = INVENTORY;
                    }

                    break;

                case POPUP:
                    
                    bool clickedOK = Game1.inventory.GetLastAdded().GetDescBox().Update();

                    if (clickedOK)
                    {
                        inGameState = NORMAL;
                    }

                    break;

                case INVENTORY:
                    Console.WriteLine("INVENTORY");
                    break;
            }
        }

        public override void Draw()
        {
            base.Draw();

            room.DrawRoom();

            switch (inGameState)
            {
                case NORMAL:
                    if (room.GetClickable() != null)
                    {
                        for (int i = 0; i < clickables.Count(); i++)
                        {
                            Clickable curr = clickables[i];

                            spriteBatch.Draw(curr.GetImg(), curr.GetHitbox(), Color.White);
                        }
                    }
                    break;

                case POPUP:
                    Game1.inventory.GetLastAdded().GetDescBox().Draw();
                    break;
            }
        }
    }
}
