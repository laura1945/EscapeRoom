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
    class Toggle : Clickable
    {
        private bool on;
        private Texture2D offImg;
        private string offText;

        public Toggle(int X, int Y, int width, int length) : base(X, Y, width, length)
        {
            on = true;
        }

        //Accessors
        public bool GetOnState()
        {
            return on;
        }

        public override Texture2D GetImg()
        {
            if (on)
            {
                return base.GetImg();
            }

            return offImg;
        }

        public override string GetText()
        {
            if (on)
            {
                return base.GetText();
            }

            return offText;
        }

        //Modifiers
        public void SetOnState(bool on)
        {
            this.on = on;
        }

        public void SetOffText(string text)
        {
            offText = text;
        }

        public override void Click()
        {
            on = !on;
        }
    }
}
