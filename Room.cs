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
    public class Room
    {
        protected ContentManager Content;
        protected SpriteBatch spriteBatch;
        protected int screenWidth;
        protected int screenHeight;

        protected string name;

        protected Room back;
        protected Room front;
        protected Room right;
        protected Room left;

        public ItemStack itemStack;
        protected List<Key> keys;

        protected Texture2D roomImg;
        protected Texture2D yellowTintImg;
        public Texture2D keyImg;

        protected Rectangle roomRec;

        protected Clickable bg;

        public Room(string name, ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            Game1.test = 3; //testing

            yellowTintImg = Content.Load<Texture2D>("Images/Sprites/hitbox");
            keyImg = Content.Load<Texture2D>("Images/Sprites/Key");

            this.name = name;
            this.Content = Content;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.spriteBatch = spriteBatch;

            itemStack = new ItemStack();
            keys = new List<Key>();
        }
        
        public void SetConnection(Room connectedRoom, string direction)
        {
            switch (direction)
            {
                case "back":
                    back = connectedRoom;
                    break;

                case "front":
                    front = connectedRoom;
                    break;

                case "right":
                    right = connectedRoom;
                    break;

                case "left":
                    left = connectedRoom;
                    break;
            }
        }

        public virtual void LoadContent()
        {
            roomRec = new Rectangle(0, 0, screenWidth, screenHeight);
            bg = new Clickable(0, 0, screenWidth, screenHeight);
            bg.SetImg(roomImg);
        }

        public ItemStack GetItemStack()
        {
            return itemStack;
        }

        public List<Key> GetKeys()
        {
            return keys;
        }

        public virtual void UpdateRoom()
        {

        }

        public virtual void DrawRoom()
        {
            spriteBatch.Draw(roomImg, roomRec, Color.White);
        }

        public virtual Clickable GetBG()
        {
            return bg;
        }

        public virtual Clickable GetClickable()
        {
            if (!itemStack.IsEmpty())
            {
                return itemStack.Top().GetClickable();
            }

            return null;
        }

    }
}
