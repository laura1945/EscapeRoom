using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    class Item
    {
        private bool collectable;
        private bool progress;
        private bool condition;

        public Item()
        {
           
        }

        public void SetCollectable()
        {
            collectable = true;
        }

        public void SetProgress()
        {
            progress = true;
        }

        public void SetCondition()
        {
            condition = true;
        }
    }
}
