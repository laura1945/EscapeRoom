// Author: Laura Zhan
// File Name: Room.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages the data in a general room

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
        //variables for images and text
        protected ContentManager Content;
        protected SpriteBatch spriteBatch;

        //stores screen width and height
        protected int screenWidth;
        protected int screenHeight;

        //name of room
        protected string name;

        //room connections
        protected Room back;
        protected Room front;
        protected Room right;
        protected Room left;
        protected List<Room> connections;

        //stores items, keys, and collectables in room
        public ItemStack itemStack;
        protected List<Key> keys;
        public Item collectable;

        //general room images
        protected Texture2D roomImg;
        protected Texture2D hitboxImg;
        public Texture2D keyImg;

        //rectangle box of room
        protected Rectangle roomRec;

        //clickable associated with room image
        protected Clickable bg;

        //key descriptions
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
            //load images
            hitboxImg = Content.Load<Texture2D>("Images/Sprites/hitbox");
            keyImg = Content.Load<Texture2D>("Images/Sprites/Key");

            //set general info of room
            this.name = name;
            this.Content = Content;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.spriteBatch = spriteBatch;

            //initialize lists
            itemStack = new ItemStack();
            keys = new List<Key>();
            connections = new List<Room>();

            //set key descriptions
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
        
        //Pre: connectedRoom and direction are initialized values
        //Post: none
        //Desc: connects room to other rooms
        public void SetConnection(Room connectedRoom, string direction)
        {
            //sets each room connection according to its relative direction to the room
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

            //add room to list of connections
            connections.Add(connectedRoom);
        }

        //Pre: none
        //Post: none
        //Desc: load room background image
        public virtual void LoadContent()
        {
            roomRec = new Rectangle(0, 0, screenWidth, screenHeight);
            bg = new Clickable(0, 0, screenWidth, screenHeight, roomImg);
        }

        //Pre: none
        //Post: return name
        //Desc: return name of room
        public string GetName()
        {
            return name;
        }

        //Pre: none
        //Post: return item stack
        //Desc: return item stack
        public ItemStack GetItemStack()
        {
            return itemStack;
        }

        //Pre: none
        //Post: return keys
        //Desc: return keys in room
        public List<Key> GetKeys()
        {
            return keys;
        }

        //Pre: none
        //Post: return list of rooms
        //Desc: return list of connected rooms
        public List<Room> GetConnections()
        {
            return connections;
        }

        //Pre: checkRoom is an existing room
        //Post: returns true if room is adjacent
        //Desc: checks if a room is directly connected to another room
        public bool IsAdjacent(Room checkRoom)
        {
            //run for number of connections
            for (int i = 0; i < connections.Count(); i++)
            {
                //return true if checkRoom is one of the adjacent rooms
                if (connections[i].GetName().Equals(checkRoom.GetName()))
                {
                    return true;
                }
            }

            return false;
        }

        //Pre: none
        //Post: return a clickable
        //Desc: return the room background clickable
        public virtual Clickable GetBG()
        {
            return bg;
        }

        //Pre: none
        //Post: return clickable
        //Desc: return the clickable of the top item in stack
        public virtual Clickable GetClickable()
        {
            //run if stack isn't empty
            if (!itemStack.IsEmpty())
            {
                //return the clickable of the top item in stack
                return itemStack.Top().GetClickable();
            }

            return null;
        }

        //Pre: none
        //Post: return item
        //Desc: return the top item in stack
        public Item GetItem()
        {
            //run if stack isn't empty
            if (!itemStack.IsEmpty())
            {
                //return top item in stack
                return itemStack.Top();
            }

            return null;
        }

        //Pre: none
        //Post: none
        //Desc: remove collectable in room
        public void RemoveCollectable()
        {
            collectable = null;
        }

        //Pre: potentialKeys is an existing list of keys
        //Post: none
        //Desc: update the list of keys in a room
        public void UpdateKeysList(List<Key> potentialKeys)
        {
            //store list of keys in inventory
            List<Key> invKeys = Game1.inventory.keys;

            //run for number of potential keys in room
            for (int i = 0; i < potentialKeys.Count(); i++)
            {
                //run for number of keys in inventory
                for (int j = 0; j < invKeys.Count(); j++)
                {
                    //run if a key in the inventory matches a potential key in the room
                    if (potentialKeys[i].GetName().Equals(invKeys[j].GetName()))
                    {
                        //remove the key from the room (since they already got it from another room)
                        keys.Remove(potentialKeys[i]);
                        i--;
                        break;
                    }
                }
            }
        }
    }
}
