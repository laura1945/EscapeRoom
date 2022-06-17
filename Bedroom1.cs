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
    public class Bedroom1 : Room
    {
        private Texture2D reflectNoteImg;
        private Texture2D timeRiddleImg;

        private Item reflectNoteItem;
        private Item timeRiddleItem;

        private Clickable reflectNote;
        private Clickable timeRiddleNote;

        private Key atticKey;
        private Key ballroomKey;
        private Key bedroom2Key;

        public Bedroom1(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Bedroom I", Content, spriteBatch, screenWidth, screenHeight)
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/bedroom_1");
            base.LoadContent();
        }

        public override void LoadContent()
        {
            //Images
            reflectNoteImg = Content.Load<Texture2D>("Images/Sprites/ReflectionNote");
            timeRiddleImg = Content.Load<Texture2D>("Images/Sprites/TimeRiddleNote");

            //Clickables
            reflectNote = new Clickable(100, 300, 100, 50, reflectNoteImg);
            timeRiddleNote = new Clickable(400, 300, 100, 50, timeRiddleImg);

            reflectNote.SetHitBoxImg(hitboxImg);
            timeRiddleNote.SetHitBoxImg(hitboxImg);

            //Items
            reflectNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note on reflection", reflectNoteImg, "A note found under the carpet.");
            timeRiddleItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Riddle", timeRiddleImg, "A riddle to solve.");

            reflectNoteItem.SetClickable(reflectNote);
            timeRiddleItem.SetClickable(timeRiddleNote);

            //stacks
            itemStack.Push(timeRiddleItem);
            itemStack.Push(reflectNoteItem);

            //keys
            ballroomKey = new Key(Content, spriteBatch, screenWidth, screenHeight, ballKeyDesc[0], keyImg, ballKeyDesc[1], Game1.ballroom);
            atticKey = new Key(Content, spriteBatch, screenWidth, screenHeight, atticKeyDesc[0], keyImg, atticKeyDesc[1], Game1.attic);
            bedroom2Key = new Key(Content, spriteBatch, screenWidth, screenHeight, bed2KeyDesc[0], keyImg, bed2KeyDesc[1], Game1.attic);

            ballroomKey.SetClickable(new Clickable(400, 525, 100, 40, keyImg));
            atticKey.SetClickable(new Clickable(150, 525, 100, 40, keyImg));
            bedroom2Key.SetClickable(new Clickable(300, 540, 100, 40, keyImg));

            keys.Add(atticKey);
            keys.Add(ballroomKey);
            keys.Add(bedroom2Key);
        }
    }
}
