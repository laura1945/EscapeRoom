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
    public class PopUp : InGame
    {
        private Texture2D itemImg;
        private string name;
        private string details;

        //fixed
        private Texture2D okButtonImg;
        private Texture2D bgImg;

        private Rectangle bgRec;
        private Rectangle itemImgRec;

        private Vector2 nameLoc;
        private Vector2 detailsLoc;

        private Clickable okButton;

        public PopUp(string name, Texture2D itemImg, string details, ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base(Content, spriteBatch, screenWidth, screenHeight)
        {
            this.name = name;
            this.itemImg = itemImg;
            this.details = details;

            okButtonImg = Content.Load<Texture2D>("Images/Sprites/OkButton");
            bgImg = Content.Load<Texture2D>("Images/Backgrounds/WoodBackground");

            bgRec = new Rectangle(300, 300, bgImg.Width / 2, bgImg.Height / 2);
            itemImgRec = new Rectangle(bgRec.X, bgRec.Y + bgRec.Height / 2, 100, 100);

            nameLoc = new Vector2(bgRec.X, bgRec.Y + 20);
            detailsLoc = new Vector2(bgRec.X, bgRec.Y + 40);

            okButton = new Clickable(bgRec.Right - okButtonImg.Width, bgRec.Bottom - okButtonImg.Height, okButtonImg.Width, okButtonImg.Height);
            okButton.SetImg(okButtonImg);
        }

        public override void Update()
        {
            Console.WriteLine("update PopUp");

            if (Game1.CheckHit(okButton.GetHitbox()))
            {
                inGameState = NORMAL;
                Console.WriteLine("NORMAL");
            }

            
        }

        public override void Draw()
        {
            spriteBatch.Draw(bgImg, bgRec, Color.White);
            spriteBatch.DrawString(statFont, name, nameLoc, Color.White);
            spriteBatch.DrawString(statFont, details, detailsLoc, Color.White);
            spriteBatch.Draw(itemImg, itemImgRec, Color.White);
            spriteBatch.Draw(okButton.GetImg(), okButton.GetHitbox(), Color.White);
        }
    }
}
