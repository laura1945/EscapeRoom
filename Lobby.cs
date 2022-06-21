// Author: Laura Zhan
// File Name: Lobby.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages the data in the lobby

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
        //images of item
        private Texture2D clothHBImg;
        private Texture2D pryImg;

        //item in room
        public Item pryBar;

        //clickable associated with pry item
        private Clickable pryClickable;

        //keys lobby
        private Key ballroomKey;
        private Key diningKey;

        public Lobby(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Lobby", Content, spriteBatch, screenWidth, screenHeight)
        {
            //load lobby image and general room content
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/Lobby");
            base.LoadContent();
        }

        //Pre: none
        //Post: none
        //Desc: load data for lobby room
        public override void LoadContent()
        {
            //Images
            clothHBImg = Content.Load<Texture2D>("Images/Sprites/hitbox");
            pryImg = Content.Load<Texture2D>("Images/Sprites/FloorboardPry");

            //Items
            pryBar = new Item("Floorboard Pry Bar", pryImg, "A floorboard pry bar was found beneath the table cloth.");

            //clickables
            pryClickable = new Clickable(500, 410, 120, 90, pryImg);
            pryClickable.SetHitBoxImg(clothHBImg);
            pryBar.SetClickable(pryClickable);

            //add item to stack
            itemStack.Push(pryBar);

            //load keys and set their data
            ballroomKey = new Key(ballKeyDesc[0], keyImg, ballKeyDesc[1], Game1.ballroom);
            diningKey = new Key(diningKeyDesc[0], keyImg, diningKeyDesc[1], Game1.diningHall);

            ballroomKey.SetClickable(new Clickable(915, 525, 100, 40, keyImg));
            diningKey.SetClickable(new Clickable(150, 525, 100, 40, keyImg));

            ballroomKey.SetHelperItem(pryBar);
            diningKey.SetHelperItem(pryBar);

            keys.Add(diningKey);
            keys.Add(ballroomKey);
            
        }
    }
}
