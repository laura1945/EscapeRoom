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
        private Texture2D wilterNoteImg;
        private Texture2D cagedNoteImg; 

        private Item wilterNoteItem;
        private Item cagedNoteItem;

        private Clickable wilterNote;
        private Clickable cagedNote;

        private Key bedroom1Key;
        private Key diningKey;
        private Key libraryKey;

        public Bedroom2(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Bedroom II", Content, spriteBatch, screenWidth, screenHeight)
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/bedroom_2");
            base.LoadContent();
        }

        public override void LoadContent()
        {
            //Images
            wilterNoteImg = Content.Load<Texture2D>("Images/Sprites/WiltersNote");
            cagedNoteImg = Content.Load<Texture2D>("Images/Sprites/cagedNote");

            //Clickables
            wilterNote = new Clickable(100, 300, 100, 50, wilterNoteImg);
            cagedNote = new Clickable(400, 300, 100, 50, cagedNoteImg);

            wilterNote.SetHitBoxImg(hitboxImg);
            cagedNote.SetHitBoxImg(hitboxImg);

            //Items
            wilterNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note on reflection", wilterNoteImg, "A note found under the carpet.");
            cagedNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Riddle", cagedNoteImg, "A riddle to solve.");

            wilterNoteItem.SetClickable(wilterNote);
            cagedNoteItem.SetClickable(cagedNote);

            //stacks
            itemStack.Push(cagedNoteItem);
            itemStack.Push(wilterNoteItem);
            
            //keys
            bedroom1Key = new Key(Content, spriteBatch, screenWidth, screenHeight, "Ballroom Key", keyImg, "A key that leads to bedroom I", Game1.bedroom1);
            diningKey = new Key(Content, spriteBatch, screenWidth, screenHeight, "Dinring Hall Key", keyImg, "A key that leads to bedroom I", Game1.bedroom1);

            bedroom1Key.SetClickable(new Clickable(915, 525, 100, 40, keyImg));
            diningKey.SetClickable(new Clickable(915, 525, 100, 40, keyImg));

            //keys.Add(atticKey);

            //keys
            //ballroomKey = new Key(Content, spriteBatch, screenWidth, screenHeight, "Ballroom Key", keyImg, "A key that leads to the ballroom.", Game1.ballroom);
            //atticKey = new Key(Content, spriteBatch, screenWidth, screenHeight, "Attic Key", keyImg, "A key that leads to the attic.", Game1.attic);
            //bedroom2Key = new Key(Content, spriteBatch, screenWidth, screenHeight, "Bedroom II Key", keyImg, "A key that leads to bedroom II.", Game1.attic);

            //ballroomKey.SetClickable(new Clickable(915, 525, 100, 40, keyImg));
            //atticKey.SetClickable(new Clickable(150, 525, 100, 40, keyImg));
            //bedroom2Key.SetClickable(new Clickable(300, 540, 100, 40, keyImg));

            //keys.Add(atticKey);
            //keys.Add(ballroomKey);
            //keys.Add(bedroom2Key);
        }
    }
}
