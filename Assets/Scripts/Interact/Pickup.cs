using UnityEngine;

public class Pickup : InteractBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int itemID;

    public override void Interact(GameObject interactor)
    {
        var player = interactor.GetComponent<PlayerController>();
        if (player == null) return;
        if (player.hasItem) return;
        player.AddItem(itemID);
        Destroy(gameObject);
        Debug.Log("Item pickup");
    }

}
