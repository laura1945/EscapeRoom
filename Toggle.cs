// Author: Laura Zhan
// File Name: Toggle.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class represents toggle clickables

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
        //tracks on/off state of button
        private bool on;

        //representations for off state
        private Texture2D offImg;
        private string offText;

        public Toggle(int X, int Y, int width, int length) : base(X, Y, width, length)
        {
            //set default state to be on
            on = true;
        }

        //Pre: none
        //Post: return bool
        //Desc: returns true if button is on
        public bool GetOnState()
        {
            return on;
        }

        //Pre: none
        //Post: return image
        //Desc: return on or off image
        public override Texture2D GetImg()
        {
            //return on image if button is on, return off image otherwise
            if (on)
            {
                return base.GetImg();
            }

            return offImg;
        }

        //Pre: none
        //Post: return text
        //Desc: return on or off text
        public override string GetText()
        {
            //return on text if button is on, return off text otherwise
            if (on)
            {
                return base.GetText();
            }

            return offText;
        }

        //Pre: on is an initialized bool
        //Post: none
        //Desc: sets button to be on
        public void SetOnState(bool on)
        {
            this.on = on;
        }

        //Pre: text is an existing string
        //Post: none
        //Desc: set off state text
        public void SetOffText(string text)
        {
            offText = text;
        }

        //Pre: none
        //Post: none
        //Desc: turns button on if off, turns it off if on
        public override void Click()
        {
            on = !on;
        }
    }
}
