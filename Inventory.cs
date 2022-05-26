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
    public class Inventory : InGame
    {
        private Texture2D invLayImg;

        private Clickable invLayout;

        private List<Item> items;
        private List<Item> collectables;
        private List<Item> keys;

        public Inventory(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            items = new List<Item>();
            collectables = new List<Item>();
            keys = new List<Item>();
            
            //Images
            invLayImg = Content.Load<Texture2D>("Images/Sprites/InventoryLayout");

            //Displayed
            invLayout = new Clickable(screenWidth - invLayImg.Width, 0, invLayImg.Width, invLayImg.Height);
            invLayout.SetImg(invLayImg);
        }

        public Item GetLastAdded()
        {
            //Console.WriteLine("items count: " + items.Count());
            return items[items.Count() - 1];
        }

        public void AddItem(Item newItem)
        {
            items.Add(newItem);
            Console.WriteLine(newItem.GetName() + " added.");
        }

        public new void Update()
        {

        }

        public void DrawInventory()
        {
            spriteBatch.Draw(invLayImg, invLayout.GetHitbox(), Color.White);
        }
    }
}
