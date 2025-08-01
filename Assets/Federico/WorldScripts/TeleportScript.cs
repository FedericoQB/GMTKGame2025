using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform emptyExit;
    GameObject player;

    public bool isLocked;

    public int nextLevelIndex;
    [SerializeField] public static bool continuesOnToNextLevel;

    [SerializeField] private AudioClip teleporting;

    SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite turnedOn;
    [SerializeField] private Sprite turnedOff;

    [SerializeField] private List<GameObject> shadow = new List<GameObject>();
    [SerializeField] private GameObject currentShadow;

    int indexForShadow;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        ExitTeleport.emptyExitGlobal = emptyExit;

        if (isLocked)
        {
            spriteRenderer.sprite = turnedOff;
        }
        else
        {
            spriteRenderer.sprite = turnedOn;
        }
    }

    public void Teleport()
    {
        if (!isLocked)
        {
            PlaySound();

            TeleportAnimation();

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

        TeleportAnimationShadow();
    }

    public void ActivateTeleporter()
    {
        isLocked = false;
        spriteRenderer.sprite = turnedOn;
    }

    public void DeactivateTeleporter()
    {
        isLocked = true;
        spriteRenderer.sprite = turnedOff;
    }

    private void PlaySound()
    {
        SoundFXManager.instance.PlaySoundFXClip(teleporting, transform, 1f);
    }

    // This is for Player Animations
    private void TeleportAnimation()
    {
        Debug.Log("Teleporting");
        P_movment.isPlayingTeleAnimation = true;
        P_movment.playerAnimator.SetBool("isTeleporting", true); // Set the animator scripts and functions into Pontus Player movement
        StartCoroutine(WaitForTeleportAnimationPlayer());
    }

    private IEnumerator WaitForTeleportAnimationPlayer()
    {
        yield return null;
        
        AnimatorStateInfo stateInfo = P_movment.playerAnimator.GetCurrentAnimatorStateInfo(0);

        while (stateInfo.IsName("TeleportAnim"))
        {
            yield return null;
            stateInfo = P_movment.playerAnimator.GetCurrentAnimatorStateInfo(0);
        }
        yield return new WaitForSeconds(1.3f);

        P_movment.isPlayingTeleAnimation = false;
        P_movment.playerAnimator.SetBool("isTeleporting", false);

        player.transform.position = emptyExit.position;

        while (stateInfo.IsName("TeleportBackAnim"))
        {
            yield return null;
            stateInfo = P_movment.playerAnimator.GetCurrentAnimatorStateInfo(0);
        }

        Debug.Log("Teleporting Finished");
    }

    // This is for animations of Shadow Figures
    private void TeleportAnimationShadow()
    {
        Debug.Log("Teleporting Shadow");
        sadow_Mov.isPlayingTeleAnimation = true;
        sadow_Mov.shadowAnimator.SetBool("isTeleporting", true); // Set the animator scripts and functions into Pontus Player movement
        StartCoroutine(WaitForTeleportAnimationShadow());
    }

    private IEnumerator WaitForTeleportAnimationShadow()
    {
        yield return null;

        AnimatorStateInfo stateInfo = sadow_Mov.shadowAnimator.GetCurrentAnimatorStateInfo(0);

        while (stateInfo.IsName("TeleportForwardS"))
        {
            yield return null;
            stateInfo = sadow_Mov.shadowAnimator.GetCurrentAnimatorStateInfo(0);
        }
        yield return new WaitForSeconds(1.3f);

        sadow_Mov.isPlayingTeleAnimation = false;
        sadow_Mov.shadowAnimator.SetBool("isTeleporting", false);

        foreach (GameObject gameObject in shadow)
        {
            shadow[indexForShadow].transform.position = emptyExit.position;
            indexForShadow++;
        }

        indexForShadow = 0;

        while (stateInfo.IsName("TeleportBackwardS"))
        {
            yield return null;
            stateInfo = sadow_Mov.shadowAnimator.GetCurrentAnimatorStateInfo(0);
        }

        Debug.Log("Teleporting Shadow Finished");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shadow"))
        {
            shadow.Add(collision.gameObject);

            Debug.Log("Shadow has entered Teleport Trigger");
        }
    }
}

public static class ExitTeleport
{
    public static Transform emptyExitGlobal;
}
