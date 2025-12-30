using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData
{
    public int itemID;
    public string itemName;
    public int itemQuantity;
    public int itemSlot;
}

public class PlayerInventory : MonoBehaviour
{
    public int totalSlot;
    public int inventorySlots = 5;
    public List<ItemData> items = new List<ItemData>();

    public void AddItem(int itemID, string itemName,int itemQuantity)
    {
        var itemExist = items.Find(i  => i.itemID == itemID);

        if (itemExist != null)
        {
            itemExist.itemQuantity += itemQuantity;
            return;
        }

        for (int i = 0; i<inventorySlots; i++)
        {
            var slotExist = items.Find(s => s.itemSlot == i);

            if (slotExist == null)
            {
                itemExist = new ItemData()
                {
                    itemID = itemID,
                    itemName = itemName,
                    itemQuantity = itemQuantity,
                    itemSlot = i
                };

                items.Add(itemExist);
                totalSlot++;
                return;

            }
        }

        Debug.Log("There's no inventory slot available");

    }

    public void RemoveItem(int itemID)
    {
        var itemExist = items.Find(i => i.itemID == itemID);

        if (itemExist == null) return;

        if (itemExist.itemQuantity > 1)
        {
            itemExist.itemQuantity--;
        }
        else
        {
            items.Remove(itemExist);
            totalSlot--;
        }
    }


}
