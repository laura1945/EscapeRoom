// Author: Laura Zhan
// File Name: Ballroom.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages the data in the ballroom

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
        //stores images of items
        private Texture2D sheetMusicImg;
        private Texture2D polaroidImg;

        //items
        private Item sheetMusicItem;
        private Item polaroidItem;

        //clickables associated with items
        private Clickable sheetMusic;
        private Clickable polaroid;

        //keys in ballroom
        private Key bedroom1Key;
        private Key kitchenKey;

        public Ballroom(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Ballroom", Content, spriteBatch, screenWidth, screenHeight)
        {
            //load ballroom image and general room content
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/Ballroom");
            base.LoadContent();
        }

        //Pre: none
        //Post: none
        //Description: load items in ballroom
        public override void LoadContent()
        {
            //load item images
            sheetMusicImg = Content.Load<Texture2D>("Images/Sprites/SheetMusic");
            polaroidImg = Content.Load<Texture2D>("Images/Sprites/Polaroid");

            //Clickables
            sheetMusic = new Clickable(190, 525, 100, 25, sheetMusicImg);
            polaroid = new Clickable(1000, 20, 100, 50, polaroidImg);

            sheetMusic.SetHitBoxImg(hitboxImg);
            polaroid.SetHitBoxImg(hitboxImg);

            //Items
            sheetMusicItem = new Item("Piano Sheet Music", sheetMusicImg, "A piano version of a German song.");

            sheetMusicItem.SetClickable(sheetMusic);

            //add sheet music item onto itemStack
            itemStack.Push(sheetMusicItem);

            //keys
            bedroom1Key = new Key(bed1KeyDesc[0], keyImg, bed1KeyDesc[1], Game1.bedroom1);
            kitchenKey = new Key(kitchenKeyDesc[0], keyImg, kitchenKeyDesc[1], Game1.kitchen);

            bedroom1Key.SetClickable(new Clickable(480, 375, 60, 30, keyImg));
            kitchenKey.SetClickable(new Clickable(455, 40, 130, 100, keyImg));

            //add keys to list of keys in ballroom
            keys.Add(bedroom1Key);
            keys.Add(kitchenKey);

            //create polaroid collectable
            polaroidItem = new Item("Polaroid Photo", sheetMusicImg, "A memory of better times, found behind the curtains.");
            polaroidItem.SetClickable(polaroid);
            polaroidItem.SetCollectable();

            //set collectable to polaroid
            collectable = polaroidItem;
        }
    }
}
