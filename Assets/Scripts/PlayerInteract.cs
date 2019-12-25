using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] public KeyCode interactKey;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null &&
            Input.GetKeyDown(interactKey))
        {
            other.gameObject.GetComponent<Interactable>().Interact();
        }
        
    }
}
