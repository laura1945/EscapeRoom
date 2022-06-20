// Author: Laura Zhan
// File Name: Clickable.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class holds info for anything that user can interact with a mouse

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
        //location and dimensions of clickable
        protected Vector2 location;
        protected Vector2 dimensions;
        protected Rectangle hitboxRec;
        protected Clickable hitboxCB;
        
        //images associated with clickable
        protected Texture2D img;
        protected Texture2D hitBoxImg;

        //text info of clickable 
        protected string text;
        protected SpriteFont font;
        protected Color colour;

        //declaring a type called clickAction
        public delegate void clickAction();

        //clickAction is an instance of clickAction - the function to run when user left clicks on the clickable
        private clickAction clickFunc;

        //the function to run when user right clicks on the clickable
        private clickAction rightClickFunc;

        //constructor without images or text
        public Clickable(int X, int Y, int width, int height) 
        {
            //set location and dimensions
            location = new Vector2(X, Y);
            dimensions = new Vector2(width, height);
            hitboxRec = new Rectangle(X, Y, width, height);
        }
        
        //constructor with image
        public Clickable(int X, int Y, int width, int height, Texture2D img)
        {
            //set location, images and dimensions
            location = new Vector2(X, Y);
            dimensions = new Vector2(width, height);
            hitboxRec = new Rectangle(X, Y, width, height);
            
            this.img = img;
            
        }

        //constructor with text
        public Clickable(int X, int Y, string text, SpriteFont font, Color colour)
        {
            //set location and text details
            location = new Vector2(X, Y);
            this.text = text;
            this.font = font;
            this.colour = colour;
        }

        //Pre: X and Y are initialized values
        //Post: none
        //Description: set location
        public void SetLoc(int X, int Y)
        {
            location.X = X;
            location.Y = Y;
        }

        //Pre: newBox is an initialized rectangle
        //Post: none
        //Desc: sets hitbox/location
        public void SetHitbox(Rectangle newBox)
        {
            hitboxRec = newBox;
            location.X = newBox.X;
            location.Y = newBox.Y;
        }

        //Pre: img is an initialized value
        //Post: none
        //Desc: set image of clickable
        public void SetImg(Texture2D img)
        {
            this.img = img;
        }

        //Pre: text is an initialized value
        //Post: none
        //Desc: set text of clickable
        public void SetText(string text)
        {
            //set text and font
            this.text = text;
            font = Game1.font;
        }

        //Pre: clickAction is an existing function that takes no parameters and returns nothing
        //Post: none
        //Desc: set the function associated with left clicking on the clickable
        public void SetClick(clickAction clickAction)
        {
            clickFunc = clickAction;
        }

        //Pre: action is an existing function that takes no parameters and returns nothing
        //Post: none
        //Desc: set the function associated with right clicking on the clickable
        public void SetRightClick(clickAction action)
        {
            rightClickFunc = action;
        }

        //Pre: hitBoxImg is an initialized image
        //Post: none
        //Desc: set image representing hitbox
        public void SetHitBoxImg(Texture2D hitBoxImg)
        {
            this.hitBoxImg = hitBoxImg;
            hitboxCB = new Clickable(hitboxRec.X, hitboxRec.Y, hitboxRec.Width, hitboxRec.Height, hitBoxImg);
        }
        
        //Pre: none
        //Post: returns image of clickable
        //Desc: returns image of clickable
        public virtual Texture2D GetImg()
        {
            return img;
        }

        //Pre: none
        //Post: returns text of clickable
        //Desc: returns text of clickable
        public virtual string GetText()
        {
            return text;
        }

        //Pre: none
        //Post: returns font of text
        //Desc: returns font of text
        public SpriteFont GetFont()
        {
            return font;
        }

        //Pre: none
        //Post: returns colour of text
        //Desc: returns colour of text
        public Color GetColour()
        {
            return colour;
        }

        //Pre: none
        //Post: returns location of clickable
        //Desc: returns location of clickable
        public Vector2 GetLoc()
        {
            return location;
        }

        //Pre: none
        //Post: returns hitbox of clickable
        //Desc: returns hitbox of clickable
        public Rectangle GetHitbox()
        {
            return hitboxRec;
        }

        //Pre: none
        //Post: returns hitbox image of clickable
        //Desc: returns hitbox image of clickable
        public Texture2D GetHitboxImg()
        {
            return hitBoxImg;
        }

        //Pre: none
        //Post: returns clickable
        //Desc: returns clickable associated with hitbox
        public Clickable GetHitClickable()
        {
            return hitboxCB;
        }

        //Pre: none
        //Post: returns X dimension location
        //Desc: returns X dimension location
        public int X()
        {
            return (int)location.X;
        }

        //Pre: none
        //Post: returns Y dimension location
        //Desc: returns Y dimension location
        public int Y()
        {
            return (int)location.Y;
        }

        //Pre: none
        //Post: returns width of clickable
        //Desc: returns width of clickable
        public int GetWidth()
        {
            return img.Width;
        }

        //Pre: none
        //Post: returns height of clickable
        //Desc: returns height of clickable
        public int GetHeight()
        {
            return img.Height;
        }

        //Pre: none
        //Post: none
        //Desc: calls function associated with left click on clickable
        public virtual void Click()
        {
            clickFunc();
        }

        //Pre: none
        //Post: none
        //Desc: calls function associated with right click on clickable
        public virtual void RightClick()
        {
            if (rightClickFunc != null)
            {
                rightClickFunc();
            }
        }
    }
}
