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
        private Texture2D viewItemsBttImg;
        private Texture2D itemsPageImg;

        public Clickable invLayout;
        public Clickable viewItemsBtt;
        public Clickable itemsPage;

        public List<Item> items;
        private List<Item> collectables;
        public List<Key> keys;

        public Inventory(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            items = new List<Item>();
            collectables = new List<Item>();
            keys = new List<Key>();
            
            //Images
            invLayImg = Content.Load<Texture2D>("Images/Sprites/InventoryLayout");
            viewItemsBttImg = Content.Load<Texture2D>("Images/Sprites/ViewItemsButton");
            itemsPageImg = Content.Load<Texture2D>("Images/Sprites/ItemPage");

            //Displayed
            invLayout = new Clickable(screenWidth - invLayImg.Width, 0, invLayImg.Width, invLayImg.Height, invLayImg);
            itemsPage = new Clickable(invLayout.X(), invLayout.Y(), invLayout.GetWidth(), invLayout.GetHeight(), itemsPageImg);

            //Clickable
            viewItemsBtt = new Clickable(invLayout.GetHitbox().Left + 50, invLayout.GetHitbox().Top + invLayout.GetHeight()/4 + 10, viewItemsBttImg.Width, viewItemsBttImg.Height, viewItemsBttImg);

            
        }

        //accessors
        public Item GetLastAdded()
        {
            //Console.WriteLine("items count: " + items.Count());
            return items[items.Count() - 1];
        }

        public List<Key> GetKeys()
        {
            return keys;
        }

        //modifiers
        public void AddItem(Item newItem)
        {
            items.Add(newItem);
            //Console.WriteLine(newItem.GetName() + " added.");
        }

        public void AddKey(Key key)
        {
            keys.Add(key);
        }
    }
}
