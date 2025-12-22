using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int itemID;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject interactor)
    {
        var player = interactor.GetComponent<PlayerController>();
        if (player == null) return;
        if (player.hasItem) return;
        player.AddItem(itemID);
        Destroy(gameObject);
        Debug.Log("Item pickup");
    }

}
