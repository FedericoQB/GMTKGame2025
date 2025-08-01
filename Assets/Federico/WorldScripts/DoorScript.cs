using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform emptyExit;
    GameObject player;

    public bool isLocked;

    public int nextLevelIndex;
    [SerializeField] private bool continuesOnToNextLevel;

    [SerializeField] private AudioClip openingDoor;

    [SerializeField] private GameObject shadow;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        ExitTeleport.emptyExitGlobal = emptyExit;
    }

    public void OpenDoor()
    {
        if (!isLocked)
        {
            PlaySound();

            player.transform.position = emptyExit.position;

            if (continuesOnToNextLevel) LevelManager.currentLevel = nextLevelIndex;
        }
        else
        {
            Debug.Log("Is Locked");
        }
    }

    public void ShadowTeleport()
    {
        PlaySound();

        shadow.transform.position = emptyExit.position;
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
        SoundFXManager.instance.PlaySoundFXClip(openingDoor, transform, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shadow"))
        {
            Debug.Log("Shadow has entered Door Trigger");
            shadow = collision.gameObject;
        }
    }
}

public static class ExitDoor
{
    public static Transform emptyExitGlobal;
}
