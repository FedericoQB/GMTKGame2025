using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform emptyExit;
    GameObject player;

    public bool isLocked;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OpenDoor()
    {
        if (!isLocked)
        {
            player.transform.position = emptyExit.position;
        }
        else
        {

        }
    }
}
