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
    class Room
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

        protected ItemStack itemStack;
        protected CoverStack itemCovers;

        protected Texture2D roomImg;

        protected Rectangle roomRec;

        protected Clickable bg;

        private bool justAdded;

        public Room(string name, ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            Game1.test = 3; //testing

            this.name = name;
            this.Content = Content;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.spriteBatch = spriteBatch;

            itemStack = new ItemStack();

            justAdded = false;
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

        public virtual void UpdateRoom()
        {
            //Item itemAdded;

            //if (!itemStack.IsEmpty())
            //{
            //    if (Game1.CheckHit(itemCovers.Top().GetRec()))
            //    {
            //        itemAdded = itemStack.Pop();
            //        Game1.inventory.AddItem(itemAdded);

            //        itemCovers.Pop();

            //        Console.WriteLine("just added " + itemAdded.GetName());
            //    }
            //}
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
