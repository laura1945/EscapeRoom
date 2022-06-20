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
    public class Room
    {
        protected ContentManager Content;
        protected SpriteBatch spriteBatch;
        protected int screenWidth;
        protected int screenHeight;

        protected string name;

        protected Room back;
        protected Room front;
        protected Room right;
        protected Room left;
        protected List<Room> connections;

        public ItemStack itemStack;
        protected List<Key> keys;
        public Item collectable;

        protected Texture2D roomImg;
        protected Texture2D hitboxImg;
        public Texture2D keyImg;

        protected Rectangle roomRec;

        protected Clickable bg;

        public string[] lobbyKeyDesc;
        protected string[] ballKeyDesc;
        protected string[] kitchenKeyDesc;
        protected string[] diningKeyDesc;
        protected string[] labKeyDesc;
        protected string[] bed1KeyDesc;
        protected string[] bed2KeyDesc;
        protected string[] atticKeyDesc;
        protected string[] libraryKeyDesc;
        protected string[] musicKeyDesc;

        public Room(string name, ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight)
        {
            hitboxImg = Content.Load<Texture2D>("Images/Sprites/hitbox");
            keyImg = Content.Load<Texture2D>("Images/Sprites/Key");

            this.name = name;
            this.Content = Content;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.spriteBatch = spriteBatch;

            itemStack = new ItemStack();
            keys = new List<Key>();
            connections = new List<Room>();

            lobbyKeyDesc = new string[] { "Lobby Key", "A key to the lobby." };
            ballKeyDesc = new string[] { "Ballroom Key", "A key that leads to the ballroom." };
            kitchenKeyDesc = new string[] { "Kitchen Key", "A key that leads to the kitchen." };
            diningKeyDesc = new string[] { "Dining Hall Key", "A key that leads to the dining hall." };
            labKeyDesc = new string[] { "Lab Key", "A key that leads to the lab." };
            bed1KeyDesc = new string[] { "Bedroom I Key", "A key that leads to bedroom I." };
            bed2KeyDesc = new string[] { "Bedroom II Key", "A key that leads to bedroom II." };
            atticKeyDesc = new string[] { "Attic Key", "A key that leads to the attic." };
            libraryKeyDesc = new string[] { "Library Key", "A key that leads to the library." };
            musicKeyDesc = new string[] { "Music Room Key", "A key that leads to the music room." };
        }
        
        public void SetConnection(Room connectedRoom, string direction)
        {
            switch (direction)
            {
                case "back":
                    back = connectedRoom;
                    break;

                case "front":
                    front = connectedRoom;
                    break;

                case "right":
                    right = connectedRoom;
                    break;

                case "left":
                    left = connectedRoom;
                    break;
            }

            connections.Add(connectedRoom);
        }

        public virtual void LoadContent()
        {
            roomRec = new Rectangle(0, 0, screenWidth, screenHeight);
            bg = new Clickable(0, 0, screenWidth, screenHeight, roomImg);
        }

        public string GetName()
        {
            return name;
        }

        public ItemStack GetItemStack()
        {
            return itemStack;
        }

        public List<Key> GetKeys()
        {
            return keys;
        }

        public List<Room> GetConnections()
        {
            return connections;
        }

        public bool IsAdjacent(Room checkRoom)
        {
            for (int i = 0; i < connections.Count(); i++)
            {
                if (connections[i].GetName().Equals(checkRoom.GetName()))
                {
                    return true;
                }
            }

            return false;
        }

        public virtual void UpdateRoom()
        {

        }

        public virtual void DrawRoom()
        {
            spriteBatch.Draw(roomImg, roomRec, Color.White);
        }

        public virtual Clickable GetBG()
        {
            return bg;
        }

        public virtual Clickable GetClickable()
        {
            if (!itemStack.IsEmpty())
            {
                return itemStack.Top().GetClickable();
            }

            return null;
        }

        public Item GetItem()
        {
            if (!itemStack.IsEmpty())
            {
                return itemStack.Top();
            }

            return null;
        }

        public void RemoveCollectable()
        {
            collectable = null;
        }

        public void UpdateKeysList(List<Key> potentialKeys)
        {
            List<Key> invKeys = Game1.inventory.keys;

            Console.WriteLine("invKeys count: " + invKeys.Count());
            Console.WriteLine("potentialKeys count: " + potentialKeys.Count());

            for (int i = 0; i < potentialKeys.Count(); i++)
            {
                for (int j = 0; j < invKeys.Count(); j++)
                {
                    if (potentialKeys[i].GetName().Equals(invKeys[j].GetName()))
                    {
                        keys.Remove(potentialKeys[i]);
                        i--;
                        break;
                    }
                }
            }
        }
    }
}
