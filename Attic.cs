// Author: Laura Zhan
// File Name: Attic.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages the data in the attic room

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
    public class Attic : Room
    {
        //components of a letter collectable
        private Texture2D letterImg;
        private Item letterItem;
        private Clickable letter;

        public Attic(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Attic", Content, spriteBatch, screenWidth, screenHeight)
        {
            //load attic background image
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/Attic");

            //load general room content
            base.LoadContent();
        }

        //Pre: none
        //Post: none
        //Description: load items in attic
        public override void LoadContent()
        {
            //load letter image
            letterImg = Content.Load<Texture2D>("Images/Sprites/Letter");

            //initialize letter clickable and assign it a hitbox image
            letter = new Clickable(500, 300, 30, 60, letterImg);
            letter.SetHitBoxImg(hitboxImg);

            //create letter item
            letterItem = new Item("Letter", letterImg, "A sincere letter found on the desk.");
            letterItem.SetClickable(letter);
            letterItem.SetCollectable();

            //set collectable to be the letter
            collectable = letterItem;
        }
    }
}
