// Author: Laura Zhan
// File Name: ItemStack.cs
// Project Name: EscapeRoom
// Creation Date: May 18, 2022
// Modified Date: June 20, 2022
// Description: This class manages a stack of items in a room

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom
{
    public class ItemStack
    {
        //stores list of items
        private List<Item> items;

        public ItemStack()
        {
            //initialize list of items
            items = new List<Item>();
        }

        //Pre: newItem is an initialized item
        //Post: none
        //Desc: add a new item to top of stack
        public void Push(Item newItem)
        {
            items.Add(newItem);
        }

        //Pre: none
        //Post: return item
        //Desc: remove and return item on top of stack
        public Item Pop()
        {
            //store result item (default value is null)
            Item result = null;

            //check if list is empty
            if (!IsEmpty())
            {
                //store top item in result and remove top item
                result = items[Size() - 1];
                items.RemoveAt(Size() - 1);
            }

            //return top item
            return result;
        }

        //Pre: none
        //Post: return an item
        //Desc: return item at top of stack
        public Item Top()
        {
            //store result item (default value is null)
            Item result = null;
            //check if list is empty

            if (!IsEmpty())
            {
                //store top item
                result = items[Size() - 1];
            }

            //return item
            return result;
        }

        //Pre: none
        //Post: returns a bool that indicates if list is empty
        //Desc: returns true if list is empty
        public bool IsEmpty()
        {
            //return the statement if size is 0 (true if it is 0)
            return Size() == 0;
        }

        //Pre: none
        //Post: return an int rep. size
        //Desc: return size of item list
        public int Size()
        {
            return items.Count();
        }
    }
}
