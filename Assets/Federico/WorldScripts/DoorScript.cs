using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform emptyExit;
    GameObject player;

    public bool isLocked;
    public bool cameraNextDoor;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        ExitStuff.emptyExitGlobal = emptyExit;
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

public static class ExitStuff
{
    public static Transform emptyExitGlobal;
}
