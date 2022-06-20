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
    public class Library : Room
    {
        private Texture2D sacrificeNoteImg;
        private Texture2D knowledgeNoteImg;

        private Item sacrificeNoteItem;
        private Item knowledgeNoteItem;

        private Clickable sacrificeNote;
        private Clickable knowledgeNote;

        private Key musicKey;

        public Library(ContentManager Content, SpriteBatch spriteBatch, int screenWidth, int screenHeight) : base("Library", Content, spriteBatch, screenWidth, screenHeight)
        {
            roomImg = Content.Load<Texture2D>("Images/Backgrounds/Library");
            base.LoadContent();
        }

        public override void LoadContent()
        {
            //Images
            sacrificeNoteImg = Content.Load<Texture2D>("Images/Sprites/SacrificeNote");
            knowledgeNoteImg = Content.Load<Texture2D>("Images/Sprites/knowledgeNote");

            //Clickables
            sacrificeNote = new Clickable(630, 520, 100, 70, sacrificeNoteImg);
            knowledgeNote = new Clickable(370, 400, 200, 40, knowledgeNoteImg);

            sacrificeNote.SetHitBoxImg(hitboxImg);
            knowledgeNote.SetHitBoxImg(hitboxImg);

            //Items
            sacrificeNoteItem = new Item("Note on sacrifice", sacrificeNoteImg, "A poetic entry found within a pile of logs.");
            knowledgeNoteItem = new Item("Note on knowledge", knowledgeNoteImg, "A confession found on the fireplace.");

            sacrificeNoteItem.SetClickable(sacrificeNote);
            knowledgeNoteItem.SetClickable(knowledgeNote);

            //stacks
            itemStack.Push(knowledgeNoteItem);
            itemStack.Push(sacrificeNoteItem);

            //keys
            musicKey = new Key(musicKeyDesc[0], keyImg, musicKeyDesc[1], Game1.musicRoom);

            musicKey.SetClickable(new Clickable(810, 550, 90, 30, hitboxImg));

            keys.Add(musicKey);
        }
    }
}
