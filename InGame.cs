// Author: Laura Zhan
// File Name: InGame.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages the logic in a game

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    public class InGame : GameState
    {
        //for testing purposes
        private bool showHitbox = false;

        //stores current room player is in
        public Room room;

        //tracks selected item in inventory
        private Item selectedItem;

        //stores images displayed on an item's popup
        private Texture2D popupItemImg;
        private Texture2D okButtonImg;
        private Texture2D popupBG;

        //stores images shown in inventory
        private Texture2D invIconImg;
        private Texture2D XBttImg;
        private Texture2D greyBoxImg;

        //stores images on key popup
        private Texture2D goRoomBttImg;
        private Texture2D cancelBttImg;

        //locations of popup and its content
        private Rectangle popupRec;
        private Rectangle popupItemImgRec;
        private Vector2 nameLoc;
        private Vector2 detailsLoc;

        //dimensions of items in inventory
        private int[] invItemsHBDim = new int[] { 65, 63 };

        //clickables that will be linked to their associated items
        private Clickable okButton;
        private Clickable popupBGDisp;
        private Clickable popupName;
        private Clickable popupItem;
        private Clickable popupDetails;
        private Clickable invIcon;
        private Clickable XButton;
        private Clickable selectedHB;
        private Clickable goToRoomBtt;
        private Clickable cancelBtt;
        private Clickable keyErrorMsg;

        public InGame(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            //sets room to be lobby
            room = Game1.lobby;
        }
        
        //Pre: none
        //Post: none
        //Description: Loads images and other variables used in game
        public override void LoadContent()
        {
            //load parent class's content (GameState)
            base.LoadContent();

            //load images
            okButtonImg = Content.Load<Texture2D>("Images/Sprites/OkButton");
            popupBG = Content.Load<Texture2D>("Images/Backgrounds/WoodBackground");
            invIconImg = Content.Load<Texture2D>("Images/Sprites/Boxes");
            XBttImg = Content.Load<Texture2D>("Images/Sprites/XButton");
            goRoomBttImg = Content.Load<Texture2D>("Images/Sprites/GoToRoomBtt");
            cancelBttImg = Content.Load<Texture2D>("Images/Sprites/CancelButton");
            greyBoxImg = Content.Load<Texture2D>("Images/Sprites/GreyBox");

            //load locations
            popupRec = new Rectangle((screenWidth - popupBG.Width)/2, (screenHeight - popupBG.Height) / 2, popupBG.Width, popupBG.Height);

            nameLoc = new Vector2(popupRec.X, popupRec.Y + 20);
            detailsLoc = new Vector2(popupRec.X, popupRec.Y + 40);

            //general popup clickables
            okButton = new Clickable(popupRec.Right - okButtonImg.Width, popupRec.Bottom - okButtonImg.Height, okButtonImg.Width, okButtonImg.Height, okButtonImg);
            popupBGDisp = new Clickable(popupRec.X, popupRec.Y, popupRec.Width, popupRec.Height, popupBG);
            backBtt = new Clickable(Game1.inventory.itemsPage.X(), Game1.inventory.itemsPage.GetHeight() - backBttImg.Height / 4, backBttImg.Width / 4, backBttImg.Height / 4, backBttImg);

            //key popup clickables
            goToRoomBtt = new Clickable(popupRec.Right - goRoomBttImg.Width, popupRec.Bottom - goRoomBttImg.Height, goRoomBttImg.Width, goRoomBttImg.Height, goRoomBttImg);
            cancelBtt = new Clickable(popupRec.Left, popupRec.Bottom - goRoomBttImg.Height, cancelBttImg.Width, cancelBttImg.Height, cancelBttImg);
            keyErrorMsg = new Clickable(popupRec.X, popupRec.Y + 20, "You can only go to rooms directly connected to the room \nyou're currently in.", Game1.font, Color.White);

            //inventory icon and x button in inventory
            invIcon = new Clickable(screenWidth - invIconImg.Width/10, screenHeight - invIconImg.Height / 10, invIconImg.Width / 10, invIconImg.Height / 10, invIconImg);
            XButton = new Clickable(Game1.inventory.invLayout.GetHitbox().Right - XBttImg.Width/10, Game1.inventory.invLayout.GetHitbox().Top, XBttImg.Width / 10, XBttImg.Height / 10, XBttImg);

            //associate each button with an action when clicked on
            okButton.SetClick(StartNormal);
            invIcon.SetClick(ShowInventory);
            XButton.SetClick(StartNormal);
            Game1.inventory.viewItemsBtt.SetClick(ShowItems);
            backBtt.SetClick(ShowInventory);
            cancelBtt.SetClick(StartNormal);
        }

        //Pre: newKey is an existing key
        //Post: none
        //Description: shows a popup displaying key's info 
        private void KeyPopup(Key newKey)
        {
            //clear list of displayables and clickables
            displayables.Clear();
            clickables.Clear();

            //add background room image
            displayables.Add(room.GetBG());

            //add displayables to list
            displayables.Add(invIcon);
            displayables.Add(popupBGDisp);

            //add clickables to list
            clickables.Add(goToRoomBtt);
            clickables.Add(cancelBtt);

            //store clickable of key
            Clickable keyClickable = newKey.GetClickable();

            //update key info
            popupItemImg = keyClickable.GetImg();
            popupItemImgRec = new Rectangle(popupRec.X + popupItemImg.Width / 8, popupRec.Top + (popupRec.Y - popupRec.Height / 8), popupItemImg.Width, popupItemImg.Height);
            popupName = new Clickable(popupRec.X, popupRec.Y + 20, newKey.GetName(), Game1.font, Color.White);
            popupItem = new Clickable(popupItemImgRec.X, popupItemImgRec.Y, popupItemImgRec.Width / 8, popupItemImgRec.Height / 8, popupItemImg);
            popupDetails = new Clickable(popupRec.X, popupRec.Y + 40, newKey.GetDetails(), Game1.font, Color.White);

            //change to room associated with key if user clicks go to room button
            goToRoomBtt.SetClick(ChangeRoom);

            //add displayables 
            displayables.Add(popupName);
            displayables.Add(popupItem);
            displayables.Add(popupDetails);
            displayables.Add(goToRoomBtt);
            displayables.Add(cancelBtt);

            //Pre: none
            //Post: none
            //Description: change rooms
            void ChangeRoom()
            {
                //store room associated with key
                Room newRoom = newKey.GetRoom();

                //change room
                room = newKey.GetRoom();

                //resume normal ingame status
                StartNormal();
            }
        }

        //Pre: none
        //Post: none
        //Description: add item to inventory and show popup 
        private void popStackAndPopUp()
        {
            //store top item in stack
            Item addedItem = room.GetItemStack().Top();

            //run if item is able to be picked up, which can happen if the associated helper item is selected in inventory OR there's no helper item
            if (selectedItem == addedItem.GetHelperItem() || addedItem.GetHelperItem() == null)
            {
                //remove item from stack in room
                room.GetItemStack().Pop();

                //add item to inventory
                Game1.inventory.AddItem(addedItem);

                //set left click of item in inventory to select an item
                addedItem.GetClickable().SetClick(PassSelectAddedItem);

                //set right click of item in inventory to show popup
                addedItem.GetClickable().SetRightClick(PassShowPopAddedItem);

                //Pre: none
                //Post: none
                //Description: pass SelectItem function the newly added item
                void PassSelectAddedItem()
                {
                    SelectItem(addedItem);
                }

                //Pre: none
                //Post: none
                //Description: pass ShowPopup the added item
                void PassShowPopAddedItem()
                {
                    ShowPopup(addedItem);
                }

                //display popup automatically when user picks up an item
                ShowPopup(addedItem);
            }
        }

        //Pre: addedItem is an existing item
        //Post: none
        //Description: select or deselect an item in inventory
        private void SelectItem(Item item)
        {
            //temporary storage of selectedItem
            Item temp = selectedItem;

            //remove yellow tint
            displayables.Remove(selectedHB);

            //check if selected item isn't empty and isn't already selected
            if (selectedItem == null || !selectedItem.GetName().Equals(item.GetName()))
            {
                //set selected item
                selectedItem = item;

                //reset location of yellow tint, add to displayables
                selectedHB = new Clickable(selectedItem.GetClickable().GetHitbox().X, selectedItem.GetClickable().GetHitbox().Y, selectedItem.GetClickable().GetHitbox().Width, selectedItem.GetClickable().GetHitbox().Height, selectedItem.GetClickable().GetHitboxImg());
                displayables.Add(selectedHB);

                //refresh inventory UI if selected item is a collectable
                if (selectedItem.IsCollectable())
                {
                    ShowInventory();
                }
            }
            else //only run if selectItem = addedItem
            {
                //deselect item
                selectedItem = null;

                //refresh inventory UI if selected item is a collectable
                if (temp.IsCollectable())
                {
                    ShowInventory();
                }
            }
        }

        //Pre: item is an existing item 
        //Post: none
        //Description: show popup for regular item
        private void ShowPopup(Item item)
        {
            //clear displayables and clickables
            displayables.Clear();
            clickables.Clear();

            //reset item info on popup
            popupItemImg = item.GetClickable().GetImg();
            popupItemImgRec = new Rectangle(popupRec.X + popupItemImg.Width / 2, popupRec.Top + (popupRec.Height / 3), popupItemImg.Width, popupItemImg.Height);
            popupName = new Clickable(popupRec.X, popupRec.Y + 20, item.GetName(), Game1.font, Color.White);
            popupItem = new Clickable(popupItemImgRec.X, popupItemImgRec.Y, popupItemImgRec.Width, popupItemImgRec.Height, popupItemImg);
            popupDetails = new Clickable(popupRec.X, popupRec.Y + 40, item.GetDetails(), Game1.font, Color.White);

            //add displayables
            displayables.Add(room.GetBG());
            displayables.Add(invIcon);
            displayables.Add(popupBGDisp);
            displayables.Add(popupName);
            displayables.Add(popupItem);
            displayables.Add(popupDetails);
            displayables.Add(okButton);

            //add clickables
            clickables.Add(okButton);
        }

        //Pre: none
        //Post: none
        //Description: run normal state of in game
        public void StartNormal()
        {
            //clear displayables and clickables
            displayables.Clear();
            clickables.Clear();

            //add room background image 
            displayables.Add(room.GetBG());
            
            //run if room has a collectable
            if (room.collectable != null)
            {
                //store collectable of room
                Clickable collectable = room.collectable.GetClickable();

                //set click to be added to inventory
                collectable.SetClick(AddCollectableToInv);

                //add collectable to clickables list
                clickables.Add(collectable);

                //show hitbox if the testing settting is turned on (or if item is potion because I like how it looks sitting on the table)
                if (showHitbox || room.collectable.GetName().Equals("Potion Bottle"))
                {
                    displayables.Add(collectable);
                }

                //Pre: none
                //Post: none
                //Description: add collectable to inventory
                void AddCollectableToInv()
                {
                    //store new instance of collectable so it doesn't get overwritten later
                    Item addedCollect = room.collectable;

                    //add to inventory
                    Game1.inventory.AddCollectable(room.collectable);

                    //set left and right click functions of collectable when clicked on
                    collectable.SetClick(PassSelectAddedCollect);
                    collectable.SetRightClick(PassShowPopAddedCollect);

                    //show popup 
                    ShowPopup(addedCollect);

                    //remove collectable from room
                    room.RemoveCollectable();

                    //Pre: none
                    //Post: none
                    //Description: pass SelectItem the collectable to be selected
                    void PassSelectAddedCollect()
                    {
                        SelectItem(addedCollect);
                    }

                    //Pre: none
                    //Post: none
                    //Description: pass ShowPopup the collectable
                    void PassShowPopAddedCollect()
                    {
                        ShowPopup(addedCollect);
                    }
                }
            }

            //store item and clickable at top of itemStack in room
            Clickable currItemCB = room.GetClickable();
            Item currItem = room.GetItem();

            //check if item clickable is empty
            if (currItemCB != null)
            {
                //set left click on item to popStackAndPopUp
                currItemCB.SetClick(popStackAndPopUp);

                //add item to clickables list
                clickables.Add(currItemCB);

                //show hitbox if the testing settting is turned on
                if (showHitbox)
                {
                    displayables.Add(currItemCB.GetHitClickable());
                }
            }
            else
            {
                //store keys in room
                List<Key> keys = room.GetKeys(); 

                //update list of keys in room
                room.UpdateKeysList(keys);

                //run for number of keys
                for (int i = 0; i < keys.Count(); i++)
                {
                    //store current key and its clickable
                    Key key = keys[i];
                    Clickable keyCB = key.GetClickable();

                    //call CheckKeyPickup on left click of key
                    keyCB.SetClick(CheckKeyPickup);

                    //add key and info to clickables list 
                    clickables.Add(keys[i].GetClickable());

                    //show hitbox if the testing settting is turned on
                    if (showHitbox)
                    {
                        displayables.Add(keyCB);
                        displayables.Add(new Clickable(keyCB.X(), keyCB.Y(), key.GetName(), Game1.font, Color.White));
                    }

                    //Pre: none
                    //Post: none
                    //Description: checks if key can be picked up, and adds it if it can be
                    void CheckKeyPickup()
                    {
                        //runs if key's helper item is selected in inventoy OR there's no associated helper item
                        if (selectedItem == key.GetHelperItem() || key.GetHelperItem() == null)
                        {
                            //add key to inventory
                            Game1.inventory.AddKey(key);

                            //show popup for key
                            KeyPopup(key);

                            //remove key from list of keys in room
                            keys.Remove(key);
                        }
                    }
                }
            }

            //add inventory icon to clickables and displayables
            clickables.Add(invIcon);
            displayables.Add(invIcon);
        }
        
        //Pre: none
        //Post: none
        //Description: show main inventory page
        private void ShowInventory()
        {
            //clear clickables and displayables
            clickables.Clear();
            displayables.Clear();

            //remove certain displayables
            displayables.Remove(backBtt);

            //add clickables
            clickables.Add(XButton);
            clickables.Add(Game1.inventory.viewItemsBtt);

            //add displayables
            displayables.Add(room.GetBG());
            displayables.Add(Game1.inventory.invLayout);
            displayables.Add(XButton);
            displayables.Add(Game1.inventory.viewItemsBtt);

            //check if selected item is empty
            if (selectedItem != null)
            {
                Clickable currSelected = new Clickable(Game1.inventory.invLayout.X() + 245, Game1.inventory.invLayout.Y() + 90, invItemsHBDim[0], invItemsHBDim[1], selectedItem.GetClickable().GetImg());

                //add selected item image to show user what's currently selected
                displayables.Add(currSelected);
            }
            
            //call function that manages keys in inventory
            ShowKeys();

            //call function that manages collectables in inventory
            DisplayCollectables();
        }

        //Pre: none
        //Post: none
        //Description: show keys in inventory
        private void ShowKeys()
        {
            //store list of keys
            List<Key> keys = Game1.inventory.GetKeys();

            //UI information
            int col = 0;
            int row = 0;
            int numCol = 2;
            int leftMargin = Game1.inventory.itemsPage.GetHitbox().Left + 128;
            int topMargin = Game1.inventory.itemsPage.GetHitbox().Top + 245;
            
            //run if list isn't empty
            if (keys != null)
            {
                //run for number of keys in list
                for (int i = 0; i < keys.Count(); i++)
                {
                    //store clickable of current key
                    Clickable keyCB = keys[i].GetClickable();
                    
                    //temporary copy of index so it won't get overwritten
                    int index = i;

                    //reset hitbox location of key
                    keyCB.SetHitbox(new Rectangle(leftMargin + col * invItemsHBDim[0], topMargin + row * invItemsHBDim[1], invItemsHBDim[0], invItemsHBDim[1]));

                    //update column number
                    col++;

                    //check if column number is greater than number of columns
                    if (col > numCol)
                    {
                        //reset column to 0
                        col = 0;

                        //add one to row number
                        row++;
                    }

                    //store hitbox of key
                    Rectangle hitbox = keyCB.GetHitbox();

                    //add displayables
                    displayables.Add(keyCB);
                    displayables.Add(new Clickable(hitbox.X + 3, hitbox.Bottom - 15, keys[i].GetRoom().GetName(), Game1.labelFont, Color.Red));

                    //add clickables
                    clickables.Add(keyCB);

                    //check if key can be picked up: key is valid if room it leads to is adjacent to current room OR leads to current room
                    if (room.IsAdjacent(keys[index].GetRoom()) || room.GetName().Equals(keys[index].GetRoom().GetName()))
                    {
                        //set function associated when clicked on key to be KeyPopupInventory
                        keyCB.SetClick(KeyPopupInventory);
                    }
                    else
                    {
                        //grey out key in inventory
                        displayables.Add(new Clickable(keyCB.X(), keyCB.Y(), keyCB.GetHitbox().Width, keyCB.GetHitbox().Height, greyBoxImg));

                        //set click to show error message
                        keyCB.SetClick(DisplayKeyError);
                    }

                    //Pre: none
                    //Post: none
                    //Description: call KeyPopup and pass it the appropriate key
                    void KeyPopupInventory()
                    {
                        KeyPopup(keys[index]);
                    }
                }
            }
        }

        //Pre: none
        //Post: none
        //Description: display error popup for key
        private void DisplayKeyError()
        {
            //clear list of displayables and clickables
            displayables.Clear();
            clickables.Clear();

            //add displayables
            displayables.Add(room.GetBG());
            displayables.Add(invIcon);
            displayables.Add(popupBGDisp);
            displayables.Add(okButton);
            displayables.Add(keyErrorMsg);

            //add clickables
            clickables.Add(okButton);
        }

        //Pre: none
        //Post: none
        //Description: display collectables in inventory
        private void DisplayCollectables()
        {
            displayables.Remove(selectedHB);

            //store list of collectables
            List<Item> collectables = Game1.inventory.GetCollectables();

            //UI display stuff
            int leftMargin = 60;
            int topMargin = 490;
            int boxDim = 70;

            //run for number of collectables
            for (int i = 0; i < collectables.Count(); i++)
            {
                //reset hitbox location
                collectables[i].GetClickable().SetHitbox(new Rectangle(Game1.inventory.itemsPage.GetHitbox().Left + leftMargin + i * boxDim, Game1.inventory.itemsPage.GetHitbox().Top + topMargin, invItemsHBDim[0], invItemsHBDim[1]));

                //add displayables and clickables
                displayables.Add(collectables[i].GetClickable());
                clickables.Add(collectables[i].GetClickable());
            }

            //check if selected item is empty and if it's a collectable
            if (selectedItem != null && selectedItem.IsCollectable())
            {
                //add yellow tint to selected clickable
                displayables.Add(selectedHB);
            }
        }

        //Pre: none
        //Post: none
        //Description: show items page of inventory
        protected void ShowItems()
        {
            //clear clickables and remove certain displayables
            clickables.Clear();
            displayables.Remove(selectedHB);
            
            //add clickables
            clickables.Add(XButton);
            clickables.Add(backBtt);

            //add displayables
            displayables.Add(Game1.inventory.itemsPage);
            displayables.Add(XButton);
            displayables.Add(backBtt);

            //UI stuff
            int col = 0;
            int row = 0;
            int colNum = 4;
            int leftMargin = 63;
            int topMargin = 138;
            int boxDim = 70;

            //run for number of items
            for (int i = 0; i < Game1.inventory.items.Count(); i++)
            {
                //reset hitbox location
                Game1.inventory.items[i].GetClickable().SetHitbox(new Rectangle(Game1.inventory.itemsPage.GetHitbox().Left + leftMargin + col*boxDim , Game1.inventory.itemsPage.GetHitbox().Top + topMargin + row*boxDim, invItemsHBDim[0], invItemsHBDim[1]));
                col++;

                //run if column is greater than number of columns
                if (col > colNum)
                {
                    //reset column and increase row number
                    col = 0;
                    row++;
                }

                //add item to displayables and clickables
                displayables.Add(Game1.inventory.items[i].GetClickable());
                clickables.Add(Game1.inventory.items[i].GetClickable());
            }

            //run if selected item is collectable
            if (selectedItem != null && !selectedItem.IsCollectable())
            {
                //add yellow tint over selected collectable
                displayables.Add(selectedHB);
            }
        }
    }
}
