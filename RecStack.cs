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
    class RecStack
    {
        private List<Rectangle> recs;

        public RecStack()
        {
            recs = new List<Rectangle>();
        }

        public void Push(Rectangle newRec)
        {
            recs.Add(newRec);
        }

        public void Pop()
        {
            if (!IsEmpty())
            {
                recs.RemoveAt(Size() - 1);
            }
        }

        //public Rectangle Top()
        //{
        //    Rectangle result = null;

        //    if (!IsEmpty())
        //    {
        //        result = recs[Size() - 1];
        //    }

        //    return result;
        //}

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public int Size()
        {
            return recs.Count();
        }
    }
}
