using UnityEngine;
using UnityEngine.InputSystem;

public class OpenDialogue : MonoBehaviour
{
    public GameObject dialogueUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDialogue(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        dialogueUI.SetActive(!dialogueUI.activeSelf);
    }
}
