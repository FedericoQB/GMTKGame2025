using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsInteractScript : MonoBehaviour
{
    public bool IsOnTop;
    public UnityEvent pushedDownAction; // Pushed down and event will Invoke
    public UnityEvent pushedUpAction; // Pushed up and event will Invoke

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsOnTop)
        {
            pushedDownAction.Invoke();
        }
        else
        {
            pushedUpAction.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");

        if (collision.tag == "Player" || collision.tag == "Shadow" || collision.tag == "Chest")
        {
            IsOnTop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Shadow" || collision.tag == "Chest")
        {
            IsOnTop = false;
        }
    }
}
