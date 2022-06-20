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
    public class Lab : Room
    {
        private Texture2D potionImg;
        private Item potionItem;
        private Clickable potion;

        public Lab(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Lab", Content, spriteBatch, screenWidth, screenHeight)
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/Lab");
            base.LoadContent();
        }

        public override void LoadContent()
        {
            potionImg = Content.Load<Texture2D>("Images/Sprites/Potion");

            potion = new Clickable(500, 300, 30, 60, potionImg);
            potion.SetHitBoxImg(hitboxImg);

            potionItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Potion Bottle", potionImg, "A bottle of unknown liquid.");
            potionItem.SetClickable(potion);
            potionItem.SetCollectable();
            collectable = potionItem;
        }
    }
}
