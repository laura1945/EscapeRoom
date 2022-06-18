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
        private Room room;
        private Lobby lobby;

        public const int NORMAL = 0;
        public const int INVENTORY = 1;
        public const int POPUP = 2;
        public int inGameState;
        private int prevGameState;

        private Item selectedItem;

        //Popup
        private Texture2D popupItemImg;
        private string name;
        private string details;

        private Texture2D okButtonImg;
        private Texture2D popupBG;
        private Texture2D invIconImg;
        private Texture2D XBttImg;
        private Texture2D goRoomBttImg;
        private Texture2D cancelBttImg;

        private Rectangle popupRec;
        private Rectangle popupItemImgRec;

        private Vector2 nameLoc;
        private Vector2 detailsLoc;
        private int[] invItemsHBDim = new int[] { 65, 63 };

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

        //private Key key;

        public InGame(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            room = Game1.lobby;
            inGameState = NORMAL;
        }
        
        public override void LoadContent()
        {
            base.LoadContent();

            okButtonImg = Content.Load<Texture2D>("Images/Sprites/OkButton");
            popupBG = Content.Load<Texture2D>("Images/Backgrounds/WoodBackground");
            invIconImg = Content.Load<Texture2D>("Images/Sprites/Boxes");
            XBttImg = Content.Load<Texture2D>("Images/Sprites/XButton");
            goRoomBttImg = Content.Load<Texture2D>("Images/Sprites/GoToRoomBtt");
            cancelBttImg = Content.Load<Texture2D>("Images/Sprites/CancelButton");

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

            invIcon = new Clickable(screenWidth - invIconImg.Width/10, screenHeight - invIconImg.Height / 10, invIconImg.Width / 10, invIconImg.Height / 10, invIconImg);
            XButton = new Clickable(Game1.inventory.invLayout.GetHitbox().Right - XBttImg.Width/10, Game1.inventory.invLayout.GetHitbox().Top, XBttImg.Width / 10, XBttImg.Height / 10, XBttImg);

            okButton.SetClick(StartNormal);
            invIcon.SetClick(ShowInventory);
            XButton.SetClick(StartNormal);
            Game1.inventory.viewItemsBtt.SetClick(ShowItems);
            backBtt.SetClick(ShowInventory);
            cancelBtt.SetClick(StartNormal);
        }

        private void KeyPopup(Key newKey)
        {
            //Game1.inventory.AddKey(newKey);
            //Console.WriteLine("key popup");
            displayables.Clear();
            clickables.Clear();

            //room images
            displayables.Add(room.GetBG());

            //inventory icon
            displayables.Add(invIcon);

            //popup
            clickables.Add(goToRoomBtt);
            clickables.Add(cancelBtt);

            displayables.Add(popupBGDisp);

            Clickable keyClickable = newKey.GetClickable();

            popupItemImg = keyClickable.GetImg();
            popupItemImgRec = new Rectangle(popupRec.X + popupItemImg.Width / 8, popupRec.Top + (popupRec.Y - popupRec.Height / 8), popupItemImg.Width, popupItemImg.Height);
            popupName = new Clickable(popupRec.X, popupRec.Y + 20, newKey.GetName(), Game1.font, Color.White);
            popupItem = new Clickable(popupItemImgRec.X, popupItemImgRec.Y, popupItemImgRec.Width / 8, popupItemImgRec.Height / 8, popupItemImg);
            popupDetails = new Clickable(popupRec.X, popupRec.Y + 40, newKey.GetDetails(), Game1.font, Color.White);

            goToRoomBtt.SetClick(ChangeRoom);

            displayables.Add(popupName);
            displayables.Add(popupItem);
            displayables.Add(popupDetails);
            displayables.Add(goToRoomBtt);
            displayables.Add(cancelBtt);

            void ChangeRoom()
            {
                Room newRoom = newKey.GetRoom();
                room = newKey.GetRoom();

                StartNormal();
            }
        }

        private void popStackAndPopUp()
        {
            Item addedItem = room.GetItemStack().Top();

            if (selectedItem == addedItem.GetHelperItem() || addedItem.GetHelperItem() == null)
            {
                room.GetItemStack().Pop();
                Game1.inventory.AddItem(addedItem);

                addedItem.GetClickable().SetClick(PassSelectAddedItem);
                addedItem.GetClickable().SetRightClick(PassShowPopAddedItem);

                void PassSelectAddedItem()
                {
                    SelectItem(addedItem);
                }

                void PassShowPopAddedItem()
                {
                    ShowPopup(addedItem);
                }

                ShowPopup(addedItem);
            }
        }

        private void SelectItem(Item addedItem)
        {
            displayables.Remove(selectedHB);

            if (selectedItem == null || !selectedItem.GetName().Equals(addedItem.GetName()))
            {
                selectedItem = addedItem;
                Console.WriteLine("selected item: " + selectedItem.GetName());
                selectedHB = new Clickable(selectedItem.GetClickable().GetHitbox().X, selectedItem.GetClickable().GetHitbox().Y, selectedItem.GetClickable().GetHitbox().Width, selectedItem.GetClickable().GetHitbox().Height, selectedItem.GetClickable().GetHitboxImg());
                displayables.Add(selectedHB);
            }
            else //only run if selectItem = addedItem
            {
                Console.WriteLine("Deselected: " + selectedItem.GetName());
                selectedItem = null;
            }
        }

        private void ShowPopup(Item item)
        {
            Console.WriteLine("going to popup");
            displayables.Clear();
            clickables.Clear();

            popupItemImg = item.GetClickable().GetImg();
            popupItemImgRec = new Rectangle(popupRec.X + popupItemImg.Width / 2, popupRec.Top + (popupRec.Height / 3), popupItemImg.Width, popupItemImg.Height);
            popupName = new Clickable(popupRec.X, popupRec.Y + 20, item.GetName(), Game1.font, Color.White);
            popupItem = new Clickable(popupItemImgRec.X, popupItemImgRec.Y, popupItemImgRec.Width, popupItemImgRec.Height, popupItemImg);
            popupDetails = new Clickable(popupRec.X, popupRec.Y + 40, item.GetDetails(), Game1.font, Color.White);

            //room images
            displayables.Add(room.GetBG());

            //inventory icon
            displayables.Add(invIcon);

            //popup
            clickables.Add(okButton);

            displayables.Add(popupBGDisp);

            displayables.Add(popupName);
            displayables.Add(popupItem);
            displayables.Add(popupDetails);
            displayables.Add(okButton);
        }

        public void StartNormal()
        {
            displayables.Clear();
            clickables.Clear();

            displayables.Add(room.GetBG());
            
            //collectables
            if (room.collectable != null)
            {
                Clickable collectable = room.collectable.GetClickable();

                collectable.SetClick(AddCollectableToInv);

                displayables.Add(collectable);
                clickables.Add(collectable);

                void AddCollectableToInv()
                {
                    Item addedCollect = room.collectable;

                    Game1.inventory.AddCollectable(room.collectable);

                    collectable.SetClick(PassSelectAddedCollect);
                    collectable.SetRightClick(PassShowPopAddedCollect);

                    ShowPopup(addedCollect);
                    room.RemoveCollectable();

                    void PassSelectAddedCollect()
                    {
                        SelectItem(addedCollect);
                    }

                    void PassShowPopAddedCollect()
                    {
                        ShowPopup(addedCollect);
                    }
                }
            }

            Clickable currItemCB = room.GetClickable();
            Item currItem = room.GetItem();

            if (currItemCB != null)
            {
                Console.WriteLine("currItem: " + currItem.GetName());

                currItemCB.SetClick(popStackAndPopUp);

                displayables.Add(currItemCB.GetHitClickable());
                clickables.Add(currItemCB);
            }
            else
            {
                Console.WriteLine("currItemCB is null");

                List<Key> keys = room.GetKeys(); //!
                room.UpdateKeysList(keys);
                Console.WriteLine("Keys: " + keys.Count());

                for (int i = 0; i < keys.Count(); i++)
                {
                    Key key = keys[i];
                    Clickable keyCB = key.GetClickable();

                    keyCB.SetClick(CheckKeyPickup);

                    displayables.Add(keyCB);
                    displayables.Add(new Clickable(keyCB.X(), keyCB.Y(), key.GetName(), Game1.font, Color.White)); //testing
                    clickables.Add(keys[i].GetClickable());

                    void CheckKeyPickup()
                    {
                        if (selectedItem == key.GetHelperItem() || key.GetHelperItem() == null)
                        {
                            Console.WriteLine("key name: " + key.GetName());
                            Game1.inventory.AddKey(key);
                            KeyPopup(key);
                            keys.Remove(key);
                        }
                    }
                }
            }

            clickables.Add(invIcon);
            displayables.Add(invIcon);
        }
        
        private void ShowInventory()
        {
            List<Key> keys = Game1.inventory.GetKeys();
            List<Item> collectables = Game1.inventory.GetCollectables();
            List<Room> connections = room.GetConnections();

            //for collectables only for now
            int col = 0;
            int leftMargin = 65;
            int topMargin = 480;
            int boxDim = 70;

            Console.WriteLine("inventory");
            clickables.Clear();

            //remove certain displayables
            displayables.Remove(backBtt);

            for (int i = 0; i < Game1.inventory.items.Count(); i++)
            {
                displayables.Remove(Game1.inventory.items[i].GetClickable());
            }

            clickables.Add(XButton);
            clickables.Add(Game1.inventory.viewItemsBtt);

            displayables.Add(Game1.inventory.invLayout);
            displayables.Add(XButton);
            displayables.Add(Game1.inventory.viewItemsBtt);

            //Keys
            if (keys != null)
            {
                Console.WriteLine("keys in inventory: " + keys.Count());

                int leftMostKeyPos = Game1.inventory.itemsPage.GetHitbox().Left + 125;
                int topMostKeyPos = Game1.inventory.itemsPage.GetHitbox().Top + 245;
                int count = 0;

                //columns
                for (int i = 0; i < 3; i++)
                {
                    //rows
                    for (int j = 0; j < 3; j++)
                    {
                        if (count <= keys.Count() - 1)
                        {
                            int index = count;

                            //reset hitbox location
                            keys[index].GetClickable().SetHitbox(new Rectangle(leftMostKeyPos + j * invItemsHBDim[0], topMostKeyPos + i * invItemsHBDim[1], invItemsHBDim[0], invItemsHBDim[1]));
                            
                            Clickable keyCB = keys[index].GetClickable();
                            Rectangle hitbox = keyCB.GetHitbox();

                            keyCB.SetClick(KeyPopupInventory);

                            Console.WriteLine("connections: " + connections.Count());
                            //for (int c = 0; c < connections.Count(); c++)
                            //{
                            //    if (connections[i].GetName().Equals(keys[index].GetRoom().GetName()))
                            //    {
                            displayables.Add(keys[index].GetClickable());
                            displayables.Add(new Clickable(hitbox.X + 3, hitbox.Y, keys[index].GetName(), Game1.labelFont, Color.Red));

                            clickables.Add(keyCB);
                            //    }
                            //}

                            void KeyPopupInventory()
                            {
                                KeyPopup(keys[index]);
                            }

                            count++;
                        }
                    }
                }
            }

            //collectables
            for (int i = 0; i < collectables.Count(); i++)
            {
                //reset hitbox location
                collectables[i].GetClickable().SetHitbox(new Rectangle(Game1.inventory.itemsPage.GetHitbox().Left + leftMargin + col * boxDim, Game1.inventory.itemsPage.GetHitbox().Top + topMargin, invItemsHBDim[0], invItemsHBDim[1]));
                col++;

                displayables.Add(collectables[i].GetClickable());
                clickables.Add(collectables[i].GetClickable());
            }

            if (selectedItem != null && selectedItem.IsCollectable())
            {
                displayables.Add(selectedHB);
            }
        }

        protected void ShowItems()
        {
            Console.WriteLine("Items page");

            clickables.Clear();

            displayables.Remove(selectedHB);
            
            clickables.Add(XButton);
            clickables.Add(backBtt);

            displayables.Add(Game1.inventory.itemsPage);
            displayables.Add(XButton);
            displayables.Add(backBtt);

            Console.WriteLine("number of items: " + Game1.inventory.items.Count());

            int col = 0;
            int row = 0;
            int leftMargin = 63;
            int topMargin = 138;
            int boxDim = 70;

            //items
            for (int i = 0; i < Game1.inventory.items.Count(); i++)
            {
                //reset hitbox location
                Game1.inventory.items[i].GetClickable().SetHitbox(new Rectangle(Game1.inventory.itemsPage.GetHitbox().Left + leftMargin + col*boxDim , Game1.inventory.itemsPage.GetHitbox().Top + topMargin + row*boxDim, invItemsHBDim[0], invItemsHBDim[1]));
                col++;

                if (col > 4)
                {
                    col = 0;
                    row++;
                }

                displayables.Add(Game1.inventory.items[i].GetClickable());
                clickables.Add(Game1.inventory.items[i].GetClickable());
            }

            if (selectedItem != null && !selectedItem.IsCollectable())
            {
                displayables.Add(selectedHB);
            }
        }
    }
}
