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

        public Room(string name, ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            Game1.test = 3; //testing

            this.name = name;
            this.Content = Content;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.spriteBatch = spriteBatch;
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
        }

        public virtual void DrawRoom()
        {
            
        }

        public virtual void UpdateRoom()
        {

        }
    }
}
