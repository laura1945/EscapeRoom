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
    public class Lobby : Room
    {
        private Texture2D clothHBImg;
        private Texture2D pryImg;
        private Texture2D pryDescImg;

        private Rectangle tableClothHB;

        public Item pryBar;

        private string pryDetails;

        private Clickable pryClickable;
        private Key ballroomKey;
        private Key diningKey;

        public Lobby(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Lobby", Content, spriteBatch, screenWidth, screenHeight)
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/Lobby");
            base.LoadContent();
        }

        public override void LoadContent()
        {
            //Images
            clothHBImg = Content.Load<Texture2D>("Images/Sprites/hitbox");
            pryImg = Content.Load<Texture2D>("Images/Sprites/FloorboardPry");

            //Rectangles
            //tableClothHB = new Rectangle(500, 410, 120, 90);

            //Details
            pryDetails = "A floorboard pry bar was found beneath the table cloth.";

            //Items
            pryBar = new Item("Floorboard Pry Bar", pryImg, pryDetails);

            //clickables
            pryClickable = new Clickable(500, 410, 120, 90, pryImg);

            pryClickable.SetHitBoxImg(clothHBImg);

            pryBar.SetClickable(pryClickable);

            //Stacks
            itemStack.Push(pryBar);

            //keys
            ballroomKey = new Key(ballKeyDesc[0], keyImg, ballKeyDesc[1], Game1.ballroom);
            diningKey = new Key(diningKeyDesc[0], keyImg, diningKeyDesc[1], Game1.diningHall);

            ballroomKey.SetClickable(new Clickable(915, 525, 100, 40, keyImg));
            diningKey.SetClickable(new Clickable(150, 525, 100, 40, keyImg));

            ballroomKey.SetHelperItem(pryBar);
            diningKey.SetHelperItem(pryBar);

            keys.Add(diningKey);
            keys.Add(ballroomKey);
            
        }

        //public override void UpdateRoom()
        //{
        //    base.UpdateRoom();
        //}

        //public override void DrawRoom()
        //{
        //    base.DrawRoom();
        //}
    }
}
