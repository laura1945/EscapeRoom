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
    public class Clickable
    {
        //mandatory
        protected Vector2 location;
        protected Vector2 dimensions;
        protected Rectangle hitbox;
        
        protected Texture2D img;
        protected string text;
        protected SpriteFont font;

        public delegate void clickAction(); //declaring a type called clickAction
        private clickAction clickFunc; //clickAction is an instance of clickAction

        public Clickable(int X, int Y, int width, int height) //pass image as parameter
        {
            location = new Vector2(X, Y);
            dimensions = new Vector2(width, height);

            hitbox = new Rectangle(X, Y, width, height);
        }

        public Clickable(int X, int Y, int width, int height, Texture2D img)
        {
            location = new Vector2(X, Y);
            dimensions = new Vector2(width, height);

            hitbox = new Rectangle(X, Y, width, height);
            this.img = img;
        }

        public Clickable(int X, int Y, string text, SpriteFont font)
        {
            location = new Vector2(X, Y);
            this.text = text;
            this.font = font;
        }

        public void SetImg(Texture2D img)
        {
            this.img = img;
        }

        public void SetText(string text, SpriteFont font = null)
        {
            this.text = text;
            this.font = Game1.font;

            if (font != null)
            {
                this.font = font;
            }
        }

        public void SetClick(clickAction clickAction)
        {
            clickFunc = clickAction;
        }
        
        //Accessors
        public virtual Texture2D GetImg()
        {
            return img;
        }

        public virtual string GetText()
        {
            return text;
        }

        public SpriteFont GetFont()
        {
            return font;
        }

        public Vector2 GetLoc()
        {
            return location;
        }

        public Rectangle GetHitbox()
        {
            return hitbox;
        }

        public int X()
        {
            return (int)location.X;
        }

        public int Y()
        {
            return (int)location.Y;
        }

        public int GetWidth()
        {
            return img.Width;
        }

        public int GetHeight()
        {
            return img.Height;
        }

        //Modifiers
        public virtual void Click()
        {
            Console.WriteLine("Clickable.Click()");
            clickFunc();
        }
    }
}
