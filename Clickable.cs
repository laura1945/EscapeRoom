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
    class Clickable
    {
        //mandatory
        protected Vector2 location;
        protected Vector2 dimensions;
        protected Rectangle hitbox;
        
        protected Texture2D img;
        protected string text;
        protected SpriteFont font;

        public Clickable(int X, int Y, int width, int height)
        {
            location = new Vector2(X, Y);
            dimensions = new Vector2(width, height);

            hitbox = new Rectangle(X, Y, width, height);
        }

        public void SetImg(Texture2D img)
        {
            this.img = img;
        }

        public void SetText(string text, SpriteFont font)
        {
            this.text = text;
            this.font = font;
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

        //Modifiers
        public virtual void Click()
        {

        }
    }
}
