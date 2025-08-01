using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestInteractionScript : MonoBehaviour
{
    public bool IsOnTop;
    private bool previousIsOnTop; // Track previous state

    public UnityEvent pushedDownAction; // Pushed down and event will Invoke
    public UnityEvent pushedUpAction;   // Pushed up and event will Invoke

    void Start()
    {
        previousIsOnTop = IsOnTop; // Initialize previous state
    }

    void Update()
    {
        if (IsOnTop != previousIsOnTop) // State changed?
        {
            if (IsOnTop)
            {
                pushedDownAction.Invoke();
            }
            else
            {
                pushedUpAction.Invoke();
            }

            previousIsOnTop = IsOnTop; // Update tracked state
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chest"))
        {
            Debug.Log("Chest has been dropped off");
            IsOnTop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Chest"))
        {
            Debug.Log("Chest has been picked up");
            IsOnTop = false;
        }
    }
}
