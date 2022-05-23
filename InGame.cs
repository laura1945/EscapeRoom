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
        protected Room room;
        protected Lobby lobby;

        protected GameState gameState;
        protected SearchingRoom searchRoomState;
        protected ItemDesc itemDesc;

        public InGame(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            lobby = new Lobby(Content, spriteBatch, screenWidth, screenHeight);
            room = lobby;

            searchRoomState = new SearchingRoom(Content, spriteBatch, screenWidth, screenHeight);
            gameState = searchRoomState;
        }

        public override void LoadContent()
        {
            base.LoadContent();

            lobby.LoadContent();
        }

        public override void Update()
        {
            gameState.Update();
        }

        public override void Draw()
        {
            base.Draw();

            room.DrawRoom();
        }
    }
}
