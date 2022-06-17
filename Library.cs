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
            sacrificeNoteImg = Content.Load<Texture2D>("Images/Sprites/ReflectionNote");
            knowledgeNoteImg = Content.Load<Texture2D>("Images/Sprites/knowledgeNote");

            //Clickables
            sacrificeNote = new Clickable(100, 300, 100, 50, sacrificeNoteImg);
            knowledgeNote = new Clickable(400, 300, 100, 50, knowledgeNoteImg);

            sacrificeNote.SetHitBoxImg(hitboxImg);
            knowledgeNote.SetHitBoxImg(hitboxImg);

            //Items
            sacrificeNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note on sacrifice", sacrificeNoteImg, "A poetic entry found within a pile of logs.");
            knowledgeNoteItem = new Item(Content, spriteBatch, screenWidth, screenHeight, "Note on knowledge", knowledgeNoteImg, "A confession found on the fireplace.");

            sacrificeNoteItem.SetClickable(sacrificeNote);
            knowledgeNoteItem.SetClickable(knowledgeNote);

            //stacks
            itemStack.Push(knowledgeNoteItem);
            itemStack.Push(sacrificeNoteItem);

            //keys
            musicKey = new Key(Content, spriteBatch, screenWidth, screenHeight, musicKeyDesc[0], keyImg, musicKeyDesc[1], Game1.musicRoom);

            musicKey.SetClickable(new Clickable(400, 525, 100, 40, keyImg));

            keys.Add(musicKey);
        }
    }
}
