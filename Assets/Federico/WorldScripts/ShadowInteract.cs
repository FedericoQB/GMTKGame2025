using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShadowInteract : MonoBehaviour
{
    public UnityEvent interactAction; // Is a variable which can be assigned to access a specific function in a script

    [SerializeField] private bool activatesOnEnter;
    [SerializeField] private bool activatesOnExit;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shadow") && activatesOnEnter)
        {
            Debug.Log("Activated");
            interactAction.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Shadow") && activatesOnExit)
        {
            Debug.Log("Activated");
            interactAction.Invoke();
        }
    }
}
