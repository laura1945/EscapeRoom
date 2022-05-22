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
    public class Item
    {
        private ContentManager Content;
        private SpriteBatch spriteBatch;

        private int screenWidth;
        private int screenHeight;

        private bool collectable;
        private bool progress;
        private bool condition;

        private string name;

        private Texture2D itemImg;
        private Texture2D itemDescImg;

        private Rectangle itemRec; //for drawing item in room
        private Rectangle itemDescRec;

        public Item(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight, string name, Texture2D itemImg, Texture2D itemDescImg, Rectangle itemRec)
        {
            this.Content = Content;
            this.spriteBatch = spriteBatch;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.name = name;
            this.itemImg = itemImg;
            this.itemRec = itemRec;
            this.itemDescImg = itemDescImg;
        }

        public void SetCollectable() //item not part of stack
        {
            collectable = true;
        }

        public void SetProgress() //item that directly progresses room state (part of stack of items)
        {
            progress = true;
        }

        public void SetCondition() //additional conditions
        {
            condition = true;
        }

        public string GetName()
        {
            return name;
        }
        
        public void LoadContent()
        {
            itemDescRec = new Rectangle(0, 0, itemDescImg.Width, itemDescImg.Height);
        }

        public void DrawItemDesc()
        {
            spriteBatch.Draw(itemDescImg, itemDescRec, Color.White);
        }

        public void DrawItemInRoom()
        {

        }
    }
}
