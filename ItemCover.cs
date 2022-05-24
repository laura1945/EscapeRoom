﻿using System;
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
    class ItemCover
    {
        private Rectangle hitbox;

        public ItemCover(Rectangle hitbox)
        {
            this.hitbox = hitbox;
        }

        public Rectangle GetRec()
        {
            return hitbox;
        }
    }
}
