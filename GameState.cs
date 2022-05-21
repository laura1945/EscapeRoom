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
    public class GameState
    {
        protected ContentManager Content;

        public GameState(ContentManager Content)
        {
            this.Content = Content;
        }

        public virtual void Update(bool newClick)
        {

        }

        public virtual void Draw()
        {

        }
    }
}
