﻿using System;
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
    class Lobby : Room
    {
        private Texture2D clothHBImg;
        private Texture2D pryImg;
        private Texture2D pryDescImg;

        private Rectangle tableClothHB;

        private Item pryBar;

        private string pryDetails;

        private Clickable pryClickable;

        public Lobby(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Lobby", Content, spriteBatch, screenWidth, screenHeight)
        {

        }

        public override void LoadContent()
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/Lobby");
            base.LoadContent();

            //Images
            
            clothHBImg = Content.Load<Texture2D>("Images/Sprites/hitbox");
            pryImg = Content.Load<Texture2D>("Images/Sprites/FloorboardPry");
            pryDescImg = Content.Load<Texture2D>("Images/Sprites/PrybarDesc");

            //Rectangles
            tableClothHB = new Rectangle(500, 410, 120, 90);

            //Details
            pryDetails = "A floorboard pry bar was found beneath the table cloth.";

            //Items
            pryBar = new Item(Content, spriteBatch, screenWidth, screenHeight, "Pry Bar", pryImg, pryDetails);

            //covers
            pryClickable = new Clickable(500, 410, 120, 90);
            pryClickable.SetImg(clothHBImg);
            pryBar.SetClickable(pryClickable);

            //Stacks
            itemCovers = new CoverStack();
            

            itemCovers.Push(new ItemCover(tableClothHB));

            itemStack.Push(pryBar);
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
