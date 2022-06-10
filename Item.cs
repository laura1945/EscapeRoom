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
        private string details;

        private Texture2D itemImg;
        private Texture2D itemDescImg;

        private Clickable clickable;
        private Item helperItem;

        public Item(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight, string name, Texture2D itemImg, string details)
        {
            this.Content = Content;
            this.spriteBatch = spriteBatch;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.name = name;
            this.itemImg = itemImg;
            this.details = details;
        }

        //modifiers
        public void SetCollectable() //item not part of stack
        {
            collectable = true;
        }

        public void SetClickable(Clickable clickable)
        {
            this.clickable = clickable;
        }

        public void SetProgress() //item that directly progresses room state (part of stack of items)
        {
            progress = true;
        }

        public void SetCondition() //additional conditions
        {
            condition = true;
        }

        public void SetHelperItem(Item item)
        {
            helperItem = item;
        }

        public void SetDetails(string details)
        {
            this.details = details;
        }

        //accessors
        public string GetName()
        {
            return name;
        }

        public Clickable GetClickable()
        {
            return clickable;
        }

        public Item GetHelperItem()
        {
            return helperItem;
        }

        public string GetDetails()
        {
            return details;
        }
    }
}
