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
    public class CoverStack
    {
        private List<ItemCover> covers;

        public CoverStack()
        {
            covers = new List<ItemCover>();
        }

        public void Push(ItemCover newRec)
        {
            covers.Add(newRec);
        }

        public void Pop()
        {
            if (!IsEmpty())
            {
                covers.RemoveAt(Size() - 1);
            }
        }

        public ItemCover Top()
        {
            ItemCover result = null;

            if (!IsEmpty())
            {
                result = covers[Size() - 1];
            }

            return result;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public int Size()
        {
            return covers.Count();
        }
    }
}
