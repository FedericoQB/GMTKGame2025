using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoorScript : MonoBehaviour
{
    public Transform emptyExit;
    GameObject player;

    public bool isLocked;

    public int nextLevelIndex;

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
            LevelManager.currentLevel = nextLevelIndex;
        }
        else
        {
            Debug.Log("Is Locked");
        }
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }

    public void LockDoor()
    {
        isLocked = true;
    }
}

public static class ExitStuff
{
    public static Transform emptyExitGlobal;
}
