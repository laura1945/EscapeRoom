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

        private Item oatsItem;
        private Item heatNoteItem;
        private Item blandNoteItem;
        //private Item microwaveItem;

        private Clickable oats;
        private Clickable heatNote;
        private Clickable blandNote;
        //private Clickable microwave;

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

            //Clickables
            oats = new Clickable(100, 300, 100, 50, oatsImg);
            heatNote = new Clickable(200, 300, 100, 50, heatNoteImg);
            blandNote = new Clickable(300, 200, 100, 50, blandNoteImg);
            //microwave = new Clickable(400, 250, 100, 70, hitboxImg);

            oats.SetHitBoxImg(hitboxImg);
            heatNote.SetHitBoxImg(hitboxImg);
            blandNote.SetHitBoxImg(hitboxImg);
            //microwave.SetHitBoxImg(hitboxImg);

            //Items
            oatsItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Quaker Oats", oatsImg, "A box of Quaker Oats.");
            heatNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note on heating oats", heatNoteImg, "A note with instructions for preparing oatmeal, found behind the baking tray.");
            blandNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note on taste", blandNoteImg, "A note critiquing the taste of Quaker oatmeal.");
            //microwaveItem = new Item("Microwave");

            //microwaveItem.SetNoInvItem();
            //microwaveItem.SetHelperItem(oatsItem);

            blandNoteItem.SetHelperItem(oatsItem);

            oatsItem.SetClickable(oats);
            heatNoteItem.SetClickable(heatNote);
            blandNoteItem.SetClickable(blandNote);
           // microwaveItem.SetClickable(microwave);

            //stacks
            itemStack.Push(blandNoteItem);
            //itemStack.Push(microwaveItem);
            itemStack.Push(heatNoteItem);
            itemStack.Push(oatsItem);

            //keys
            //keys
            ballroomKey = new Key(Content, spriteBatch, screenWidth, screenHeight, ballKeyDesc[0], keyImg, ballKeyDesc[1], Game1.ballroom);
            diningKey = new Key(Content, spriteBatch, screenWidth, screenHeight, diningKeyDesc[0], keyImg, diningKeyDesc[1], Game1.diningRoom);

            ballroomKey.SetClickable(new Clickable(915, 525, 100, 40, keyImg));
            diningKey.SetClickable(new Clickable(150, 525, 100, 40, keyImg));

            keys.Add(diningKey);
            keys.Add(ballroomKey);
        }
    }
}
