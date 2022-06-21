// Author: Laura Zhan
// File Name: Lab.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages the data in the lab

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
    public class Lab : Room
    {
        //store data of potion collectable
        private Texture2D potionImg;
        private Item potionItem;
        private Clickable potion;

        public Lab(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Lab", Content, spriteBatch, screenWidth, screenHeight)
        {
            //load lab image and general room content
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/Lab");
            base.LoadContent();
        }

        //Pre: none
        //Post: none
        //Desc: load lab room data
        public override void LoadContent()
        {
            //load potion item and set its data
            potionImg = Content.Load<Texture2D>("Images/Sprites/Potion");

            potion = new Clickable(500, 300, 30, 60, potionImg);
            potion.SetHitBoxImg(hitboxImg);

            potionItem = new Item("Potion Bottle", potionImg, "A bottle of unknown liquid.");
            potionItem.SetClickable(potion);
            potionItem.SetCollectable();
            collectable = potionItem;
        }
    }
}
