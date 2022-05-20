using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    class ItemStack
    {
        private List<Item> items;

        public ItemStack()
        {
            
        }

        public void Push(Item newItem)
        {
            items.Add(new Item());
        }

        public Item Pop()
        {
            Item result = null;

            if (!IsEmpty())
            {
                result = items[Size() - 1];
                items.RemoveAt(Size() - 1);
            }

            return result;
        }

        public Item Top()
        {
            Item result = null;

            if (!IsEmpty())
            {
                result = items[Size() - 1];
            }

            return result;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public int Size()
        {
            return items.Count();
        }
    }
}
