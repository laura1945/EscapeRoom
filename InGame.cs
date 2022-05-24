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

            Console.WriteLine("inGame update");
            clickables.Clear();
            switch (inGameState)
            {
                case NORMAL:
                    //room.UpdateRoom();
                    clickables.Add(room.GetClickable());
                    //loop through clickables, if matches hitbox, change state to POPUP
                    break;

                case POPUP:
                    Game1.inventory.GetLastAdded().GetDescBox().Update();
                    break;
            }
        }

        public override void Draw()
        {
            base.Draw();

            switch (inGameState)
            {
                case NORMAL:
                    room.DrawRoom();
                    for (int i = 0; i < clickables.Count(); i++)
                    {
                        Clickable curr = clickables[i];

                        spriteBatch.DrawString(curr.GetFont(), curr.GetText(), curr.GetLoc(), Color.White);
                    }
                    break;

                case POPUP:
                    Game1.inventory.GetLastAdded().GetDescBox().Draw();
                    break;
            }
        }
    }
}
