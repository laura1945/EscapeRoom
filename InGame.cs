using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

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

        private Rectangle popupRec;
        private Rectangle popupItemImgRec;

        private Vector2 nameLoc;
        private Vector2 detailsLoc;

        private Clickable okButton;
        private Clickable popupBGDisp;
        private Clickable popupName;
        private Clickable popupItem;
        private Clickable popupDetails;
        private Clickable invIcon;
        private Clickable XButton;

        public InGame(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            lobby = new Lobby(Content, spriteBatch, screenWidth, screenHeight);
            room = lobby;
            inGameState = NORMAL;
        }
        
        public override void LoadContent()
        {
            base.LoadContent();
            room.LoadContent();

            room.GetClickable().SetClick(popStackAndPopUp);

            okButtonImg = Content.Load<Texture2D>("Images/Sprites/OkButton");
            popupBG = Content.Load<Texture2D>("Images/Backgrounds/WoodBackground");
            invIconImg = Content.Load<Texture2D>("Images/Sprites/Boxes");
            XBttImg = Content.Load<Texture2D>("Images/Sprites/XButton");

            popupRec = new Rectangle(300, 300, popupBG.Width / 2, popupBG.Height / 2);
            popupItemImg = room.GetClickable().GetImg();
            popupItemImgRec = new Rectangle(popupRec.X, popupRec.Y + popupRec.Height / 2, 100, 100);

            nameLoc = new Vector2(popupRec.X, popupRec.Y + 20);
            detailsLoc = new Vector2(popupRec.X, popupRec.Y + 40);

            //general popup clickables
            okButton = new Clickable(popupRec.Right - okButtonImg.Width, popupRec.Bottom - okButtonImg.Height, okButtonImg.Width, okButtonImg.Height, okButtonImg);
            popupBGDisp = new Clickable(popupRec.X, popupRec.Y, popupRec.Width, popupRec.Height, popupBG);
            backBtt = new Clickable(Game1.inventory.itemsPage.X(), Game1.inventory.itemsPage.GetHeight() - backBttImg.Height / 4, backBttImg.Width / 4, backBttImg.Height / 4, backBttImg);

            //varying clickables -put into update?
            popupName = new Clickable(popupRec.X, popupRec.Y + 20, "Floorboard pry bar", Game1.font);
            popupItem = new Clickable(popupItemImgRec.X, popupItemImgRec.Y, popupItemImgRec.Width, popupItemImgRec.Height, popupItemImg);
            popupDetails = new Clickable(popupRec.X, popupRec.Y + 40, "A pry bar was found underneath the tablecloth.", Game1.font);

            invIcon = new Clickable(screenWidth - invIconImg.Width/10, screenHeight - invIconImg.Height / 10, invIconImg.Width / 10, invIconImg.Height / 10, invIconImg);
            XButton = new Clickable(Game1.inventory.invLayout.GetHitbox().Right - XBttImg.Width/10, Game1.inventory.invLayout.GetHitbox().Top, XBttImg.Width / 10, XBttImg.Height / 10, XBttImg);

            okButton.SetClick(StartNormal);
            invIcon.SetClick(ShowInventory);
            XButton.SetClick(StartNormal);
            Game1.inventory.viewItemsBtt.SetClick(ShowItems);
            backBtt.SetClick(ShowInventory);
        }

        private void popStackAndPopUp()
        {
            Item addedItem;

            //Console.WriteLine("popStackAndPopUp item count: " + room.GetItemStack().Size());
            addedItem = room.GetItemStack().Pop();
            Game1.inventory.AddItem(addedItem);
            //addedItem.GetClickable().SetHitBoxImg(null);

            addedItem.GetClickable().SetClick(SelectItem);

            void SelectItem()
            {
                selectedItem = addedItem;
                Console.WriteLine("selected item: " + selectedItem.GetName());
                displayables.Add(selectedItem.GetClickable().GetHitClickable());

                selectedItem.GetClickable().SetClick(DeselectItem);
            }

            void DeselectItem()
            {
                selectedItem.GetClickable().SetClick(SelectItem);
                Console.WriteLine("deselected: " + selectedItem.GetName());
                displayables.Remove(selectedItem.GetClickable().GetHitClickable());
                selectedItem = null;
            }

            ShowPopup();
        }

        private void ShowPopup()
        {
            Console.WriteLine("going to popup");
            displayables.Clear();
            clickables.Clear();

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
            Console.WriteLine("going back to normal");
            displayables.Clear();
            clickables.Clear();
            displayables.Add(room.GetBG());

            Clickable currItem = room.GetClickable();
            if (currItem != null)
            {
                displayables.Add(room.GetClickable());
                clickables.Add(room.GetClickable());

            }

            clickables.Add(invIcon);
            displayables.Add(invIcon);
        }
        
        private void ShowInventory()
        {
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
        }

        private void SelectItem(Item item)
        {
            selectedItem = item;
        }

        protected void ShowItems()
        {
            Console.WriteLine("Items page");

            clickables.Clear();
            
            clickables.Add(XButton);
            clickables.Add(backBtt);

            displayables.Add(Game1.inventory.itemsPage);
            displayables.Add(XButton);
            displayables.Add(backBtt);

            Console.WriteLine("number of items: " + Game1.inventory.items.Count());

            //items
            for (int i = 0; i < Game1.inventory.items.Count(); i++)
            {
                //reset hitbox location
                Game1.inventory.items[i].GetClickable().SetHitbox(new Rectangle(Game1.inventory.itemsPage.GetHitbox().Left + 63, Game1.inventory.itemsPage.GetHitbox().Top + 138, 65, 63)); 
                //Game1.inventory.items[i].GetClickable().SetClick(SelectItem);

                displayables.Add(Game1.inventory.items[i].GetClickable());
                clickables.Add(Game1.inventory.items[i].GetClickable());

                Console.WriteLine("number of items in for loop: " + Game1.inventory.items.Count());
            }

            if (selectedItem != null)
            {
                Console.WriteLine("selected item: " + selectedItem.GetName());
            }

            
        }

        public override void Draw()
        {

        }
    }
}
