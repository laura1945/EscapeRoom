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
    public class MusicRoom : Room
    {
        private List<Item> spots;
        private Item spoonSpot;
        private Item potionSpot;
        private Item letterSpot;
        private Item polaroidSpot;
        private Item cheeseSpot;

        public MusicRoom(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Music Room", Content, spriteBatch, screenWidth, screenHeight)
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/MusicRoom");
            spots = new List<Item>();

            base.LoadContent();
        }

        public override void LoadContent()
        {
            cheeseSpot = new Item("Cheese");

            cheeseSpot.SetClickable(new Clickable(500, 500, 30, 30, Game1.kitchen.cheeseImg));

            cheeseSpot.GetClickable().SetHitBoxImg(hitboxImg);

            cheeseSpot.SetHelperItem(Game1.kitchen.cheeseItem);
        }
    }
}
