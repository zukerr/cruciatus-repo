using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInteractable : MonoBehaviour
{
    [SerializeField]
    private bool disableOnInteract = true;

    public virtual void Interact()
    {
        PlayerInteractableManagement.instance.UnregisterObject(this);
        TextDisplayPrompt.instance.ClearText();
        if (disableOnInteract)
        {
            DisableTriggerCollider();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerCharacter>() != null)
        {
            //Debug.Log("Registering object: " + gameObject.name);
            PlayerInteractableManagement.instance.RegisterObject(this);
            TextDisplayPrompt.instance.DisplayTextIndefinetely("Press [Space] to interact.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerCharacter>() != null)
        {
            PlayerInteractableManagement.instance.UnregisterObject(this);
            TextDisplayPrompt.instance.ClearText();
        }
    }

    protected void DisableTriggerCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }
}
