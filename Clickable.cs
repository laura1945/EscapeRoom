﻿using System;
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
        protected Rectangle hitboxRec;
        protected Clickable hitboxCB;
        
        protected Texture2D img;
        protected Texture2D hitBoxImg;
        protected string text;
        protected SpriteFont font;
        protected Color colour;

        public delegate void clickAction(); //declaring a type called clickAction
        private clickAction clickFunc; //clickAction is an instance of clickAction
        private clickAction rightClickFunc;

        public Clickable(int X, int Y, int width, int height) //pass image as parameter
        {
            location = new Vector2(X, Y);
            dimensions = new Vector2(width, height);

            hitboxRec = new Rectangle(X, Y, width, height);
            //hitboxCB = new Clickable(hitboxRec.X, hitboxRec.Y, hitboxRec.Width, hitboxRec.Height);
        }

        //images
        public Clickable(int X, int Y, int width, int height, Texture2D img)
        {
            location = new Vector2(X, Y);
            dimensions = new Vector2(width, height);

            hitboxRec = new Rectangle(X, Y, width, height);
            
            this.img = img;
            
        }

        //text
        public Clickable(int X, int Y, string text, SpriteFont font, Color colour)
        {
            location = new Vector2(X, Y);
            this.text = text;
            this.font = font;
            this.colour = colour;
        }

        public void SetLoc(int X, int Y)
        {
            location.X = X;
            location.Y = Y;
        }

        public void SetHitbox(Rectangle newBox)
        {
            hitboxRec = newBox;
            location.X = newBox.X;
            location.Y = newBox.Y;
        }

        public void SetDimensions(double scaleFactor)
        {
            dimensions.X = (int)(img.Width * scaleFactor);
            dimensions.Y = (int)(img.Height * scaleFactor);
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

        public void SetRightClick(clickAction action)
        {
            rightClickFunc = action;
        }

        public void SetHitBoxImg(Texture2D hitBoxImg)
        {
            this.hitBoxImg = hitBoxImg;
            hitboxCB = new Clickable(hitboxRec.X, hitboxRec.Y, hitboxRec.Width, hitboxRec.Height, hitBoxImg);
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

        public Color GetColour()
        {
            return colour;
        }

        public Vector2 GetLoc()
        {
            return location;
        }

        public Rectangle GetHitbox()
        {
            return hitboxRec;
        }

        public Texture2D GetHitboxImg()
        {
            return hitBoxImg;
        }

        public Clickable GetHitClickable()
        {
            return hitboxCB;
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
            //Console.WriteLine("Clickable.Click()");
            clickFunc();
        }

        public virtual void RightClick()
        {
            if (rightClickFunc != null)
            {
                rightClickFunc();
            }
        }
    }
}
