using UnityEngine;
using UnityEngine.Events;

public class Button : InteractBase
{
    [SerializeField] private UnityEvent interactEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public override void Interact(GameObject interactor)
    {
        interactEvent?.Invoke();
    }

}
