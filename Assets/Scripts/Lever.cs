using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, Interactable
{
    [SerializeField] Animator leverAnimator;
    [SerializeField] Animator blenderAnimator;

    [SerializeField] GameObject highlight;

    public void Interact()
    {
        leverAnimator.SetTrigger("Lever");
        blenderAnimator.SetTrigger("stop");
    }

    public void Highlight(bool highlight)
    {
        this.highlight.SetActive(highlight);
    }
}
