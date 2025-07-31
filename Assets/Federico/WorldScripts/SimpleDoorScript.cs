using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDoorScript : MonoBehaviour
{
    public Transform emptyExit;
    GameObject player;

    public bool isLocked;

    public int nextLevelIndex;

    [SerializeField] private AudioClip doorOpening;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        ExitStuff.emptyExitGlobal = emptyExit;
    }

    public void OpenDoor()
    {
        if (!isLocked)
        {
            PlaySound();
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

    private void PlaySound()
    {
        SoundFXManager.instance.PlaySoundFXClip(doorOpening, transform, 1f);
    }
}

public static class ExitStuff
{
    public static Transform emptyExitGlobal;
}
