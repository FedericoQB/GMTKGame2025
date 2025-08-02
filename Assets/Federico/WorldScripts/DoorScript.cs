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

    [SerializeField] private List<GameObject> shadow = new List<GameObject>();
    [SerializeField] private GameObject currentShadow;

    private int indexForShadow;

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

            if (continuesOnToNextLevel) LevelManager.totalTorches = nextLevelIndex;
        }
        else
        {
            Debug.Log("Is Locked");
        }
    }

    public void ShadowOpenDoor()
    {
        PlaySound();

        foreach (GameObject gameObject in shadow)
        {
            shadow[indexForShadow].transform.position = emptyExit.position;
            indexForShadow++;
        }

        indexForShadow = 0;
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
            shadow.Add(collision.gameObject);
            Debug.Log("Shadow has entered Door Trigger");
        }
    }
}

public static class ExitDoor
{
    public static Transform emptyExitGlobal;
}
