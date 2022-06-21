// Author: Laura Zhan
// File Name: Item.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class is the general item players collect

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
    public class Item
    {
        //tells if item is a collectable
        private bool isCollectable;

        //name and details of item
        private string name;
        private string details;

        //image of item
        private Texture2D itemImg;

        //clickable associated with item
        private Clickable clickable;

        //item that user must have selected to pick up item
        private Item helperItem;

        public Item(string name, Texture2D itemImg, string details)
        {
            //set item data
            this.name = name;
            this.itemImg = itemImg;
            this.details = details;
        }

        //Pre: name is an existing string
        //Post: none
        //Desc: set item name
        public Item(string name)
        {
            this.name = name;
        }

        //Pre: none
        //Post: none
        //Desc: identify item as a collectable
        public void SetCollectable()
        {
            isCollectable = true;
        }

        //Pre: clickable is an existing clickable
        //Post: none
        //Desc: associate a clickable with the item
        public void SetClickable(Clickable clickable)
        {
            this.clickable = clickable;
        }

        //Pre: item is an existing item
        //Post: none
        //Desc: set an item that user must have selected in order to pick up this item
        public void SetHelperItem(Item item)
        {
            helperItem = item;
        }

        //Pre: details is initialized string
        //Post: none
        //Desc: set details of item
        public void SetDetails(string details)
        {
            this.details = details;
        }

        //Pre: none
        //Post: returns a string name
        //Desc: returns name of item
        public string GetName()
        {
            return name;
        }

        //Pre: none
        //Post: returns clickable
        //Desc: returns clickable of item
        public Clickable GetClickable()
        {
            return clickable;
        }

        //Pre: none
        //Post: returns helper item
        //Desc: returns helper item of item
        public Item GetHelperItem()
        {
            return helperItem;
        }

        //Pre: none
        //Post: returns details 
        //Desc: returns details of item
        public string GetDetails()
        {
            return details;
        }

        //Pre: none
        //Post: returns true if item is a collectable
        //Desc: returns true if item is a collectable
        public bool IsCollectable()
        {
            return isCollectable;
        }
    }
}
