using UnityEngine;

public interface IInteractable
{
    string InteractText { get; }
    void Interact(GameObject interactor);
}
