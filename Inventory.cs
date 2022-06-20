// Author: Laura Zhan
// File Name: Inventory.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class stores items, keys, and collectables that user has collected

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
        //images used
        private Texture2D invLayImg;
        private Texture2D viewItemsBttImg;
        private Texture2D itemsPageImg;

        //clickables 
        public Clickable invLayout;
        public Clickable viewItemsBtt;
        public Clickable itemsPage;

        //list of items, collectables and keys
        public List<Item> items;
        public List<Item> collectables;
        public List<Key> keys;

        public Inventory(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            //initialize lists
            items = new List<Item>();
            collectables = new List<Item>();
            keys = new List<Key>();
            
            //load images
            invLayImg = Content.Load<Texture2D>("Images/Sprites/InventoryLayout");
            viewItemsBttImg = Content.Load<Texture2D>("Images/Sprites/ViewItemsButton");
            itemsPageImg = Content.Load<Texture2D>("Images/Sprites/ItemPage");

            //load displayables
            invLayout = new Clickable(screenWidth - invLayImg.Width, 0, invLayImg.Width, invLayImg.Height, invLayImg);
            itemsPage = new Clickable(invLayout.X(), invLayout.Y(), invLayout.GetWidth(), invLayout.GetHeight(), itemsPageImg);

            //load clickables
            viewItemsBtt = new Clickable(invLayout.GetHitbox().Left + 50, invLayout.GetHitbox().Top + invLayout.GetHeight()/4 + 10, viewItemsBttImg.Width, viewItemsBttImg.Height, viewItemsBttImg);
        }

        //Pre: none
        //Post: return list of keys
        //Desc: return keys in inventory
        public List<Key> GetKeys()
        {
            return keys;
        }

        //Pre: none
        //Post: return list of collectables
        //Desc: return collectables in inventory
        public List<Item> GetCollectables()
        {
            return collectables;
        }

        //Pre: newItem is an item to be added to inventory
        //Post: none
        //Desc: add item to inventory
        public void AddItem(Item newItem)
        {
            items.Add(newItem);
        }

        //Pre: key is a collectable to be added to inventory
        //Post: none
        //Desc: add key to inventory
        public void AddKey(Key key)
        {
            keys.Add(key);
        }

        //Pre: collectable is an collectable to be added to inventory
        //Post: none
        //Desc: add collectable to inventory
        public void AddCollectable(Item collectable)
        {
            collectables.Add(collectable);
        }
    }
}
