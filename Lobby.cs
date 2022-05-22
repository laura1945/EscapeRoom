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
        private Texture2D clothHBImg;
        private Texture2D pryImg;
        private Texture2D pryDescImg;

        private Rectangle tableClothHB;
        private Rectangle pryRec;

        public Lobby(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Lobby", Content, spriteBatch, screenWidth, screenHeight)
        {

        }

        public override void LoadContent()
        {
            base.LoadContent();

            roomImg = Content.Load<Texture2D>("Images/Backgrounds/Lobby");
            clothHBImg = Content.Load<Texture2D>("Images/Sprites/hitbox");
            pryImg = Content.Load<Texture2D>("Images/Sprites/FloorboardPry");
            pryDescImg = Content.Load<Texture2D>("Images/Sprites/PrybarDesc");

            tableClothHB = new Rectangle(500, 410, 120, 90);
            //pryRec = new Rectangle()

            itemCovers = new CoverStack();
            itemStack = new ItemStack();

            itemCovers.Push(new ItemCover(tableClothHB));

            itemStack.Push(new Item(Content, spriteBatch, screenWidth, screenHeight, "pry bar", pryImg, pryDescImg, pryRec));
        }

        public override void DrawRoom()
        { 
            spriteBatch.Draw(roomImg, roomRec, Color.White);

            if (!itemCovers.IsEmpty())
            {
                spriteBatch.Draw(clothHBImg, tableClothHB, Color.White);
            }
        }

        public override void UpdateRoom()
        {
            base.UpdateRoom();

            Item newItem;

            if (!itemStack.IsEmpty())
            {
                if (Game1.CheckHit(itemCovers.Top().GetRec()))
                {
                    newItem = itemStack.Pop();
                    Game1.inventory.AddItem(newItem);

                    itemCovers.Pop();
                }
            }
            
        }
    }
}
