// Author: Laura Zhan
// File Name: Bedroom2.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages the data in bedroom 2

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
    public class Bedroom2 : Room
    {
        //stores images of items
        private Texture2D wilterNoteImg;
        private Texture2D cagedNoteImg; 

        //items
        private Item wilterNoteItem;
        private Item cagedNoteItem;

        //clickables associated with items
        private Clickable wilterNote;
        private Clickable cagedNote;

        //keys in this room
        private Key bedroom1Key;
        private Key diningKey;
        private Key libraryKey;

        public Bedroom2(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Bedroom II", Content, spriteBatch, screenWidth, screenHeight)
        {
            //load bedroom 2 image and general room content
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/bedroom_2");
            base.LoadContent();
        }

        //Pre: none
        //Post: none
        //Description: load items in bedroom 2
        public override void LoadContent()
        {
            //Images
            wilterNoteImg = Content.Load<Texture2D>("Images/Sprites/WiltersNote");
            cagedNoteImg = Content.Load<Texture2D>("Images/Sprites/cagedNote");

            //Clickables
            wilterNote = new Clickable(810, 588, 62, 30, wilterNoteImg);
            cagedNote = new Clickable(105, 405, 60, 60, cagedNoteImg);

            wilterNote.SetHitBoxImg(hitboxImg);
            cagedNote.SetHitBoxImg(hitboxImg);

            //Items
            wilterNoteItem = new Item("Note on passion", wilterNoteImg, "A diary entry found within the book.");
            cagedNoteItem = new Item("Note on escape", cagedNoteImg, "A note that hints at the location of three escapes.");

            wilterNoteItem.SetClickable(wilterNote);
            cagedNoteItem.SetClickable(cagedNote);

            //add items to stack
            itemStack.Push(cagedNoteItem);
            itemStack.Push(wilterNoteItem);

            //keys
            bedroom1Key = new Key(bed1KeyDesc[0], keyImg, bed1KeyDesc[1], Game1.bedroom1);
            diningKey = new Key(diningKeyDesc[0], keyImg, diningKeyDesc[1], Game1.diningHall);
            libraryKey = new Key(libraryKeyDesc[0], keyImg, libraryKeyDesc[1], Game1.library);

            bedroom1Key.SetClickable(new Clickable(115, 470, 130, 40, keyImg));
            diningKey.SetClickable(new Clickable(70, 115, 120, 170, keyImg));
            libraryKey.SetClickable(new Clickable(643, 420, 50, 80, keyImg));

            keys.Add(bedroom1Key);
            keys.Add(diningKey);
            keys.Add(libraryKey);
        }
    }
}
