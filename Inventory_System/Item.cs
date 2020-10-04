using UnityEngine;

namespace Inventory_System
{
    public class Item : MonoBehaviour
    {
        public int itemID;

        //if the item is stackable, then keep track of the number of items stacked
        public bool isStackable;
        public int quantity;
        [SerializeField] private int maxQuantity;

        /// <summary>
        /// Stacks an item on top of itself. The proposed item's quantity is changed
        /// by reference.
        /// </summary>
        public void Stack(Item item)
        {
            if (quantity + item.quantity > maxQuantity)
            {
                quantity = maxQuantity;
                item.quantity = (item.quantity + quantity) - maxQuantity;
            }
            else
            {
                quantity += item.quantity;
                item.quantity = 0;
            }
        }
    }
}
