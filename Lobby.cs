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
    class Lobby : Room
    {
        private Rectangle tableClothHB;

        private Texture2D clothHBImg;

        bool showHB = true;

        public Lobby(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Lobby", Content, spriteBatch, screenWidth, screenHeight)
        {
            LoadContent();
            LoadItems();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/Lobby");
            
        }

        public override void DrawRoom()
        { 
            spriteBatch.Draw(roomImg, roomRec, Color.White);

            if (showHB)
            {
                spriteBatch.Draw(clothHBImg, tableClothHB, Color.White);
            }
        }

        public override void LoadItems()
        {
            base.LoadItems();

            tableClothHB = new Rectangle(500, 410, 120, 90);
            clothHBImg = Content.Load<Texture2D>("Images/Sprites/hitbox");

            itemCovers = new RecStack();
            itemStack = new ItemStack();

            itemCovers.Push(tableClothHB);

            itemStack.Push(new Item(Content, spriteBatch, "pryer", screenWidth, screenHeight));
        }

        public void UpdateLobby()
        {
            if (CheckClick(Game1.mouse.LeftButton, Game1.prevMouse.LeftButton, tableClothHB))
            {
                showHB = false;
            }
        }
    }
}
