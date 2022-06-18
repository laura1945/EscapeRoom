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
    public class Attic : Room
    {
        private Texture2D letterImg;
        private Item letterItem;
        private Clickable letter;

        public Attic(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Attic", Content, spriteBatch, screenWidth, screenHeight)
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/Attic");
            base.LoadContent();
        }

        public override void LoadContent()
        {
            letterImg = Content.Load<Texture2D>("Images/Sprites/Letter");

            letter = new Clickable(500, 300, 30, 60, letterImg);

            letterItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Letter", letterImg, "A sincere letter found on the desk.");
            letterItem.SetClickable(letter);
            letterItem.SetCollectable();
            collectable = letterItem;
        }
    }
}
