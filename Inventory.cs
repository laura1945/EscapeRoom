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
    public class Inventory
    {
        private Texture2D invLayoutImg;

        private List<Item> items;
        private List<Item> collectables;
        private List<Item> keys;

        public Inventory()
        {
            items = new List<Item>();
            collectables = new List<Item>();
            keys = new List<Item>();
        }

        public void AddItem(Item newItem)
        {
            items.Add(newItem);
            Console.WriteLine(newItem.GetName() + " added.");
        }

        public Item GetLastAdded()
        {
            return items[items.Count() - 1];
        }

        public void DrawInventory()
        {

        }
    }
}
