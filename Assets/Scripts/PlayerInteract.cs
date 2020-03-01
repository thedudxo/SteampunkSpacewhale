using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] public KeyCode interactKey;
    [SerializeField] GameObject interactHelpBox;
    [SerializeField] Text interactHelpText;

    int interactablesInRange = 0;

    private void Start()
    {
        interactHelpText.text = interactKey.ToString();
        interactHelpBox.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null)
        {
            interactablesInRange--;
            if(interactablesInRange <= 0) interactHelpBox.SetActive(false);

            other.gameObject.GetComponent<Interactable>().Highlight(false);
            Debug.Log(interactablesInRange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null)
        {
            interactablesInRange++;
            if (interactablesInRange > 0) interactHelpBox.SetActive(true);

            other.gameObject.GetComponent<Interactable>().Highlight(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>()!= null)
        {
            if (interactablesInRange > 0)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    other.gameObject.GetComponent<Interactable>().Interact();
                }
            }
        }
    }
}
