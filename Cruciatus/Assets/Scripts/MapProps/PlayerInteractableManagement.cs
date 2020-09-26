using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractableManagement : MonoBehaviour
{
    public static PlayerInteractableManagement instance;

    private List<AInteractable> interactableObjects;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        interactableObjects = new List<AInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerInteract()
    {
        if (interactableObjects.Count > 0)
        {
            interactableObjects[0].Interact();
        }
    }

    public void RegisterObject(AInteractable interactableObject)
    {
        interactableObjects.Add(interactableObject);
    }

    public void UnregisterObject(AInteractable interactableObject)
    {
        interactableObjects.Remove(interactableObject);
    }
}
