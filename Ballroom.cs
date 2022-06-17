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
            sheetMusic = new Clickable(190, 525, 100, 25, sheetMusicImg);
            sheetMusic.SetHitBoxImg(hitboxImg);

            //Items
            sheetMusicItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Piano Sheet Music", sheetMusicImg, "A piano version of a German song.");
            
            sheetMusicItem.SetClickable(sheetMusic);

            //stacks
            itemStack.Push(sheetMusicItem);

            //keys
            bedroom1Key = new Key(Content, spriteBatch, screenWidth, screenHeight, bed1KeyDesc[0], keyImg, bed1KeyDesc[1], Game1.bedroom1);
            kitchenKey = new Key(Content, spriteBatch, screenWidth, screenHeight, kitchenKeyDesc[0], keyImg, kitchenKeyDesc[1], Game1.kitchen);

            bedroom1Key.SetClickable(new Clickable(480, 375, 60, 30, hitboxImg));
            kitchenKey.SetClickable(new Clickable(455, 40, 130, 100, hitboxImg));

            keys.Add(bedroom1Key);
            keys.Add(kitchenKey);
        }
    }
}
