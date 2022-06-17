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
        private Texture2D hungryNoteImg;
        private Texture2D pictureNoteImg;

        private Item hungryNoteItem;
        private Item pictureNoteItem;

        private Clickable hungryNote;
        private Clickable pictureNote;

        private Key kitchenKey;
        private Key labKey;
        private Key bedroom2Key;

        public DiningHall(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Lobby", Content, spriteBatch, screenWidth, screenHeight)
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/DiningHall");
            base.LoadContent();
        }

        public override void LoadContent()
        {
            //Images
            hungryNoteImg = Content.Load<Texture2D>("Images/Sprites/HungryNote");
            pictureNoteImg = Content.Load<Texture2D>("Images/Sprites/ThousandWordsNote");

            //Clickables
            hungryNote = new Clickable(80, 90, 100, 50, hungryNoteImg);
            pictureNote = new Clickable(50, 300, 120, 170, pictureNoteImg);

            hungryNote.SetHitBoxImg(hitboxImg);
            pictureNote.SetHitBoxImg(hitboxImg);

            //Items
            hungryNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note about hunger", hungryNoteImg, "A handwritten note hidden on the eagle.");
            pictureNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note about pictures", pictureNoteImg, "A handwritten note found in the vending machine.");

            hungryNoteItem.SetClickable(hungryNote);
            pictureNoteItem.SetClickable(pictureNote);

            //stacks
            itemStack.Push(pictureNoteItem);
            itemStack.Push(hungryNoteItem);

            //keys
            bedroom2Key = new Key(Content, spriteBatch, screenWidth, screenHeight, bed2KeyDesc[0], keyImg, bed2KeyDesc[1], Game1.bedroom2);
            kitchenKey = new Key(Content, spriteBatch, screenWidth, screenHeight, kitchenKeyDesc[0], keyImg, kitchenKeyDesc[1], Game1.kitchen);
            labKey = new Key(Content, spriteBatch, screenWidth, screenHeight, labKeyDesc[0], keyImg, labKeyDesc[1], Game1.lab);

            bedroom2Key.SetClickable(new Clickable(533, 320, 40, 30, hitboxImg));
            kitchenKey.SetClickable(new Clickable(495, 265, 30, 40, hitboxImg));
            labKey.SetClickable(new Clickable(530, 268, 43, 40, hitboxImg));

            keys.Add(bedroom2Key);
            keys.Add(kitchenKey);
            keys.Add(labKey);
        }
    }
}
