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
        private Texture2D oldToolImg;

        private Item reflectNoteItem;
        private Item oldToolItem;

        private Clickable reflectNote;
        private Clickable oldToolNote;

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
            oldToolImg = Content.Load<Texture2D>("Images/Sprites/OldToolNote");

            //Clickables
            reflectNote = new Clickable(600, 480, 200, 100, reflectNoteImg);
            oldToolNote = new Clickable(960, 30, 120, 180, oldToolImg);

            reflectNote.SetHitBoxImg(hitboxImg);
            oldToolNote.SetHitBoxImg(hitboxImg);

            //Items
            reflectNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note on reflection", reflectNoteImg, "A note found under the carpet.");
            oldToolItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note on reusability", oldToolImg, "A hint found behind the mirror.");

            reflectNoteItem.SetClickable(reflectNote);
            oldToolItem.SetClickable(oldToolNote);

            //stacks
            itemStack.Push(oldToolItem);
            itemStack.Push(reflectNoteItem);

            //keys
            ballroomKey = new Key(Content, spriteBatch, screenWidth, screenHeight, ballKeyDesc[0], keyImg, ballKeyDesc[1], Game1.ballroom);
            atticKey = new Key(Content, spriteBatch, screenWidth, screenHeight, atticKeyDesc[0], keyImg, atticKeyDesc[1], Game1.attic);
            bedroom2Key = new Key(Content, spriteBatch, screenWidth, screenHeight, bed2KeyDesc[0], keyImg, bed2KeyDesc[1], Game1.attic);

            atticKey.SetClickable(new Clickable(455, 535, 65, 50, hitboxImg));
            ballroomKey.SetClickable(new Clickable(605, 605, 70, 40, hitboxImg));
            bedroom2Key.SetClickable(new Clickable(800, 455, 70, 50, hitboxImg));

            atticKey.SetHelperItem(Game1.lobby.pryBar);
            ballroomKey.SetHelperItem(Game1.lobby.pryBar);
            bedroom2Key.SetHelperItem(Game1.lobby.pryBar);

            keys.Add(atticKey);
            keys.Add(ballroomKey);
            keys.Add(bedroom2Key);
        }
    }
}
