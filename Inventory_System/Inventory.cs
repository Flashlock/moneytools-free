using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory_System
{
    public class Inventory
    {
        /*
         * This class holds a list of the items in the inventory
         * Items can be added and removed
         */

        public static System.Exception unkownItemQuantity
            = new System.Exception("The Item Quantity is Unknown or Missing");

        public List<Item> items { get; private set; }

        public Inventory()
        {
            items = new List<Item>();
        }

        public virtual void AddItem(Item item)
        {
            if (item.isStackable)
            {
                List<Item> tmp = items.FindAll(i => i.itemID == item.itemID);
                foreach (Item i in tmp)
                {
                    //try to stack on each item in tmp
                    if (item.quantity == 0) break;
                    i.Stack(item);
                }
                if (item.quantity > 0) items.Add(item);
            }
            else
            {
                items.Add(item);
            }
        }

        public virtual void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public virtual void RemoveItem(int itemID)
        {
            Item item = GetLastItem(itemID);
            if (item == null) return;
            items.Remove(item);
        }

        public virtual void RemoveItem(Item item, int quantity)
        {
            List<Item> tmp = items.FindAll(i => i.itemID == item.itemID);
            if (item.isStackable)
            {
                foreach (Item i in tmp)
                {
                    if (i.quantity > quantity)
                    {
                        i.quantity -= quantity;
                        break;
                    }
                    else
                    {
                        quantity -= i.quantity;
                        items.Remove(i);
                    }
                }
            }
            else
            {
                foreach (Item i in tmp)
                {
                    if (quantity == 0) break;
                    items.Remove(i);
                    quantity--;
                }
            }
        }

        public virtual void RemoveItem(int itemID, int quantity)
        {
            Item item = GetFirstItem(itemID);
            List<Item> tmp = items.FindAll(i => i.itemID == item.itemID);
            if (item.isStackable)
            {
                foreach (Item i in tmp)
                {
                    if (i.quantity > quantity)
                    {
                        i.quantity -= quantity;
                        break;
                    }
                    else
                    {
                        quantity -= i.quantity;
                        items.Remove(i);
                    }
                }
            }
            else
            {
                foreach (Item i in tmp)
                {
                    if (quantity == 0) break;
                    items.Remove(i);
                    quantity--;
                }
            }
        }

        public Item GetFirstItem(int itemID)
        {
            return items.Find(item => item.itemID == itemID);
        }

        public Item GetLastItem(int itemID)
        {
            return items.FindLast(item => item.itemID == itemID);
        }

        public List<Item> GetAllItems(int itemID)
        {
            return items.FindAll(item => item.itemID == itemID);
        }
    }
}
