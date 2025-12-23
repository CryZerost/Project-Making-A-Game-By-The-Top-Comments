using UnityEngine;

public abstract class InteractBase : MonoBehaviour, IInteractable
{
    [SerializeField] private string _textInteract;

    public string  InteractText => _textInteract;
    public virtual void Interact(GameObject interactor) { }
}
