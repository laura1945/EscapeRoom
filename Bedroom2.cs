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
            wilterNote = new Clickable(810, 588, 62, 30, wilterNoteImg);
            cagedNote = new Clickable(105, 405, 60, 60, cagedNoteImg);

            wilterNote.SetHitBoxImg(hitboxImg);
            cagedNote.SetHitBoxImg(hitboxImg);

            //Items
            wilterNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note on passion", wilterNoteImg, "A diary entry found within the book.");
            cagedNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note on escape", cagedNoteImg, "A note that hints at the location of three escapes.");

            wilterNoteItem.SetClickable(wilterNote);
            cagedNoteItem.SetClickable(cagedNote);

            //stacks
            itemStack.Push(cagedNoteItem);
            itemStack.Push(wilterNoteItem);

            //keys
            bedroom1Key = new Key(Content, spriteBatch, screenWidth, screenHeight, bed1KeyDesc[0], keyImg, bed1KeyDesc[1], Game1.bedroom1);
            diningKey = new Key(Content, spriteBatch, screenWidth, screenHeight, diningKeyDesc[0], keyImg, diningKeyDesc[1], Game1.diningRoom);
            libraryKey = new Key(Content, spriteBatch, screenWidth, screenHeight, libraryKeyDesc[0], keyImg, libraryKeyDesc[1], Game1.library);

            bedroom1Key.SetClickable(new Clickable(115, 470, 130, 40, hitboxImg));
            diningKey.SetClickable(new Clickable(70, 115, 120, 170, hitboxImg));
            libraryKey.SetClickable(new Clickable(643, 420, 50, 80, hitboxImg));

            keys.Add(bedroom1Key);
            keys.Add(diningKey);
            keys.Add(libraryKey);
        }
    }
}
