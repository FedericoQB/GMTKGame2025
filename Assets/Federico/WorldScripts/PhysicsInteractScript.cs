using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsInteractScript : MonoBehaviour
{
    public bool IsOnTop;
    private bool previousIsOnTop; // Track previous state

    public UnityEvent pushedDownAction; // Pushed down and event will Invoke
    public UnityEvent pushedUpAction;   // Pushed up and event will Invoke

    public Sprite buttonActivatedSprite;
    public Sprite buttonDeactivatedSprite;

    void Start()
    {
        previousIsOnTop = IsOnTop; // Initialize previous state

        if (IsOnTop)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonDeactivatedSprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonActivatedSprite;
        }
    }

    void Update()
    {
        if (IsOnTop != previousIsOnTop) // State changed?
        {
            if (IsOnTop)
            {
                pushedDownAction.Invoke();

                gameObject.GetComponent<SpriteRenderer>().sprite = buttonActivatedSprite;
            }
            else
            {
                pushedUpAction.Invoke();

                gameObject.GetComponent<SpriteRenderer>().sprite = buttonActivatedSprite;
            }

            previousIsOnTop = IsOnTop; // Update tracked state
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Shadow") || collision.CompareTag("Chest"))
        {
            IsOnTop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Shadow") || collision.CompareTag("Chest"))
        {
            IsOnTop = false;
        }
    }
}
