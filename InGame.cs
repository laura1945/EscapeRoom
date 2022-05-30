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

        //Popup
        private Texture2D popupItemImg;
        private string name;
        private string details;

        private Texture2D okButtonImg;
        private Texture2D popupBG;
        private Texture2D invIconImg;

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

            popupRec = new Rectangle(300, 300, popupBG.Width / 2, popupBG.Height / 2);
            popupItemImg = room.GetClickable().GetImg();
            popupItemImgRec = new Rectangle(popupRec.X, popupRec.Y + popupRec.Height / 2, 100, 100);

            nameLoc = new Vector2(popupRec.X, popupRec.Y + 20);
            detailsLoc = new Vector2(popupRec.X, popupRec.Y + 40);

            okButton = new Clickable(popupRec.Right - okButtonImg.Width, popupRec.Bottom - okButtonImg.Height, okButtonImg.Width, okButtonImg.Height, okButtonImg);
            popupBGDisp = new Clickable(popupRec.X, popupRec.Y, popupRec.Width, popupRec.Height, popupBG);
            popupName = new Clickable(popupRec.X, popupRec.Y + 20, "Floorboard pry bar", Game1.font);
            popupItem = new Clickable(popupItemImgRec.X, popupItemImgRec.Y, popupItemImgRec.Width, popupItemImgRec.Height, popupItemImg);
            popupDetails = new Clickable(popupRec.X, popupRec.Y + 40, "A pry bar was found underneath the tablecloth.", Game1.font);
            invIcon = new Clickable(screenWidth - invIconImg.Width/10, screenHeight - invIconImg.Height / 10, invIconImg.Width / 10, invIconImg.Height / 10, invIconImg);

            okButton.SetClick(startNormal);
            invIcon.SetClick(ShowInventory);
        }

        private void popStackAndPopUp()
        {
            room.GetItemStack().Pop();
            startPopup();
        }

        private void startPopup()
        {
            Console.WriteLine("going to popup");
            displayables.Clear();
            clickables.Clear();
            displayables.Add(room.GetBG());
            displayables.Add(popupBGDisp);
            displayables.Add(popupName);
            displayables.Add(popupItem);
            displayables.Add(popupDetails);
            displayables.Add(okButton);
            clickables.Add(okButton);
        }

        public void startNormal()
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
            displayables.Add()
        }

        public override void Draw()
        {

        }
    }
}
