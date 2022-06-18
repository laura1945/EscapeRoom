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
    public class Kitchen : Room
    {
        private Texture2D oatsImg;
        private Texture2D heatNoteImg;
        private Texture2D blandNoteImg;
        private Texture2D cheeseImg;

        private Item oatsItem;
        private Item heatNoteItem;
        private Item blandNoteItem;
        private Item cheeseItem;

        private Clickable oats;
        private Clickable heatNote;
        private Clickable blandNote;
        private Clickable cheese;

        private Key diningKey;
        private Key ballroomKey;

        public Kitchen(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Kitchen", Content, spriteBatch, screenWidth, screenHeight)
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/kitchen");
            base.LoadContent();
        }

        public override void LoadContent()
        {
            //Images
            oatsImg = Content.Load<Texture2D>("Images/Sprites/QuakerOats");
            heatNoteImg = Content.Load<Texture2D>("Images/Sprites/HeatOatsNote");
            blandNoteImg = Content.Load<Texture2D>("Images/Sprites/BlandNote");
            cheeseImg = Content.Load<Texture2D>("Images/Sprites/Cheese");

            //Clickables
            oats = new Clickable(400, 40, 60, 80, oatsImg);
            heatNote = new Clickable(623, 210, 115, 95, heatNoteImg);
            blandNote = new Clickable(990, 325, 100, 135, blandNoteImg);
            cheese = new Clickable(400, 200, 100, 100, cheeseImg);

            oats.SetHitBoxImg(hitboxImg);
            heatNote.SetHitBoxImg(hitboxImg);
            blandNote.SetHitBoxImg(hitboxImg);

            //Items
            oatsItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Quaker Oats", oatsImg, "A box of Quaker Oats.");
            heatNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note on heating oats", heatNoteImg, "A note with instructions for preparing oatmeal, found behind the baking tray.");
            blandNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note on taste", blandNoteImg, "A note critiquing the taste of Quaker oatmeal.");
            
            blandNoteItem.SetHelperItem(oatsItem);

            oatsItem.SetClickable(oats);
            heatNoteItem.SetClickable(heatNote);
            blandNoteItem.SetClickable(blandNote);

            //stacks
            itemStack.Push(blandNoteItem);
            itemStack.Push(heatNoteItem);
            itemStack.Push(oatsItem);
            
            //keys
            ballroomKey = new Key(Content, spriteBatch, screenWidth, screenHeight, ballKeyDesc[0], keyImg, ballKeyDesc[1], Game1.ballroom);
            diningKey = new Key(Content, spriteBatch, screenWidth, screenHeight, diningKeyDesc[0], keyImg, diningKeyDesc[1], Game1.diningHall);

            ballroomKey.SetClickable(new Clickable(855, 87, 23, 40, hitboxImg));
            diningKey.SetClickable(new Clickable(832, 95, 18, 33, hitboxImg));

            keys.Add(diningKey);
            keys.Add(ballroomKey);

            //collectable
            cheeseItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Cheese", cheeseImg, "A slice of swiss cheese found in a pot.");
            cheeseItem.SetClickable(cheese);
            cheeseItem.SetCollectable();
            collectable = cheeseItem;
        }
    }
}
