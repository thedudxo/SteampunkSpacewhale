using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, Interactable
{
    [SerializeField] Animator leverAnimator;
    [SerializeField] Animator blenderAnimator;

    public void Interact()
    {
        leverAnimator.SetTrigger("Lever");
        blenderAnimator.SetTrigger("stop");
    }
}
