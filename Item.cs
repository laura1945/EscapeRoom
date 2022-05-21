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
    class Item
    {
        private ContentManager Content;
        private SpriteBatch spriteBatch;

        private int screenWidth;
        private int screenHeight;

        private bool collectable;
        private bool progress;
        private bool condition;

        private string name;

        public Item(ContentManager Content, SpriteBatch spriteBatch, string name, int screenWidth, int screenHeight)
        {
            this.Content = Content;
            this.spriteBatch = spriteBatch;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
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
    }
}
