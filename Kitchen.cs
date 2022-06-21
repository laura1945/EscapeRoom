// Author: Laura Zhan
// File Name: Kitchen.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages the data in the kitchen

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
        //images of items
        private Texture2D oatsImg;
        private Texture2D heatNoteImg;
        private Texture2D blandNoteImg;
        public Texture2D cheeseImg;

        //items in kitchen
        private Item oatsItem;
        private Item heatNoteItem;
        private Item blandNoteItem;
        public Item cheeseItem;

        //clickables associated with items
        private Clickable oats;
        private Clickable heatNote;
        private Clickable blandNote;
        private Clickable cheese;

        //keys in the room
        private Key diningKey;
        private Key ballroomKey;

        public Kitchen(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Kitchen", Content, spriteBatch, screenWidth, screenHeight)
        {
            //load kitchen image and load general room content
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/kitchen");
            base.LoadContent();
        }

        //Pre: none
        //Post: none
        //Desc: load kitchen data
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
            cheese = new Clickable(480, 330, 30, 30, cheeseImg);

            oats.SetHitBoxImg(hitboxImg);
            heatNote.SetHitBoxImg(hitboxImg);
            blandNote.SetHitBoxImg(hitboxImg);
            cheese.SetHitBoxImg(hitboxImg);

            //Items
            oatsItem = new Item("Quaker Oats", oatsImg, "A box of Quaker Oats.");
            heatNoteItem = new Item("Note on heating oats", heatNoteImg, "A note with instructions for preparing oatmeal, \nfound behind the baking tray.");
            blandNoteItem = new Item("Note on taste", blandNoteImg, "A note critiquing the taste of Quaker oatmeal.");
            
            blandNoteItem.SetHelperItem(oatsItem);

            oatsItem.SetClickable(oats);
            heatNoteItem.SetClickable(heatNote);
            blandNoteItem.SetClickable(blandNote);

            //add items to stack
            itemStack.Push(blandNoteItem);
            itemStack.Push(heatNoteItem);
            itemStack.Push(oatsItem);
            
            //keys
            ballroomKey = new Key(ballKeyDesc[0], keyImg, ballKeyDesc[1], Game1.ballroom);
            diningKey = new Key(diningKeyDesc[0], keyImg, diningKeyDesc[1], Game1.diningHall);

            ballroomKey.SetClickable(new Clickable(855, 87, 23, 40, keyImg));
            diningKey.SetClickable(new Clickable(832, 95, 18, 33, keyImg));

            keys.Add(diningKey);
            keys.Add(ballroomKey);

            //create cheese collectable
            cheeseItem = new Item("Cheese", cheeseImg, "A slice of swiss cheese found in a pot.");
            cheeseItem.SetClickable(cheese);
            cheeseItem.SetCollectable();
            collectable = cheeseItem;
        }
    }
}
