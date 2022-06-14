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
    public class Ballroom : Room
    {
        private Texture2D sheetMusicImg;

        private Item sheetMusicItem;

        private Clickable sheetMusic;

        private Key bedroom1Key;
        private Key kitchenKey;

        public Ballroom(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Lobby", Content, spriteBatch, screenWidth, screenHeight)
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/Ballroom");
            base.LoadContent();
        }

        public override void LoadContent()
        {
            //Images
            sheetMusicImg = Content.Load<Texture2D>("Images/Sprites/SheetMusic");

            //Clickables
            sheetMusic = new Clickable(100, 300, 10, 3, sheetMusicImg);

            //Items
            sheetMusicItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Piano Sheet Music", sheetMusicImg, "A piano version of a German song.");
            
            sheetMusicItem.SetClickable(sheetMusic);

            //stacks
            itemStack.Push(sheetMusicItem);

            //keys
            bedroom1Key = new Key(Content, spriteBatch, screenWidth, screenHeight, "Bedroom I Key", keyImg, "A key that leads to bedroom I.", Game1.bedroom1);
            kitchenKey = new Key(Content, spriteBatch, screenWidth, screenHeight, "Kitchen Key", keyImg, "A key that leads to the kitchen.", Game1.kitchen);

            bedroom1Key.SetClickable(new Clickable(200, 200, 10, 3, keyImg));
            kitchenKey.SetClickable(new Clickable(190, 50, 20, 8, keyImg));

            keys.Add(bedroom1Key);
            keys.Add(kitchenKey);
        }
    }
}
