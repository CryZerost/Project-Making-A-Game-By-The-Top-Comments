using UnityEngine;

public class Pickup : InteractBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int itemID;
    public string itemName;
    public int itemQuantity;

    public override void Interact(GameObject interactor)
    {
        var player = interactor.GetComponent<PlayerController>();
        if (player == null) return;
        if (player.playerInventory.totalSlot < player.playerInventory.inventorySlots)
        {
            player.AddItem(itemID, itemName, itemQuantity);
        }
        Destroy(gameObject);
        Debug.Log("Item pickup");
    }

}
