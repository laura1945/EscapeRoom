// Author: Laura Zhan
// File Name: DiningHall.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages the data in dining hall

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
    public class DiningHall : Room
    {
        //images of items
        private Texture2D hungryNoteImg;
        private Texture2D pictureNoteImg;
        private Texture2D spoonImg;

        //items in the room
        private Item hungryNoteItem;
        private Item pictureNoteItem;
        private Item spoonItem;

        //clickables associated with items
        private Clickable hungryNote;
        private Clickable pictureNote;
        private Clickable spoon;

        //keys in room
        private Key kitchenKey;
        private Key labKey;
        private Key bedroom2Key;

        public DiningHall(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Dining Hall", Content, spriteBatch, screenWidth, screenHeight)
        {
            //load dining hall image and general room content
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/DiningHall");
            base.LoadContent();
        }

        //Pre: none
        //Post: none
        //Desc: load dining hall room's data
        public override void LoadContent()
        {
            //Images
            hungryNoteImg = Content.Load<Texture2D>("Images/Sprites/HungryNote");
            pictureNoteImg = Content.Load<Texture2D>("Images/Sprites/ThousandWordsNote");
            spoonImg = Content.Load<Texture2D>("Images/Sprites/Spoon");

            //Clickables
            hungryNote = new Clickable(80, 90, 100, 50, hungryNoteImg);
            pictureNote = new Clickable(50, 300, 120, 170, pictureNoteImg);
            spoon = new Clickable(1000, 80, 40, 70, spoonImg);

            hungryNote.SetHitBoxImg(hitboxImg);
            pictureNote.SetHitBoxImg(hitboxImg);
            spoon.SetHitBoxImg(hitboxImg);

            //Items
            hungryNoteItem = new Item("Note about hunger", hungryNoteImg, "A handwritten note hidden on the eagle.");
            pictureNoteItem = new Item("Note about pictures", pictureNoteImg, "A handwritten note found in the vending machine.");

            hungryNoteItem.SetClickable(hungryNote);
            pictureNoteItem.SetClickable(pictureNote);

            //add items to stack
            itemStack.Push(pictureNoteItem);
            itemStack.Push(hungryNoteItem);

            //keys
            bedroom2Key = new Key(bed2KeyDesc[0], keyImg, bed2KeyDesc[1], Game1.bedroom2);
            kitchenKey = new Key(kitchenKeyDesc[0], keyImg, kitchenKeyDesc[1], Game1.kitchen);
            labKey = new Key(labKeyDesc[0], keyImg, labKeyDesc[1], Game1.lab);

            bedroom2Key.SetClickable(new Clickable(533, 320, 40, 30, hitboxImg));
            kitchenKey.SetClickable(new Clickable(495, 265, 30, 40, hitboxImg));
            labKey.SetClickable(new Clickable(530, 268, 43, 40, hitboxImg));

            keys.Add(bedroom2Key);
            keys.Add(kitchenKey);
            keys.Add(labKey);

            //create spoon collectable
            spoonItem = new Item("Silver Spoon", spoonImg, "A silver spoon hidden within the statue.");
            spoonItem.SetClickable(spoon);
            spoonItem.SetCollectable();
            collectable = spoonItem;
        }
    }
}
