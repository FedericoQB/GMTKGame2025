using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour
{
    public Transform emptyExit;
    GameObject player;

    public bool isLocked;

    public int nextLevelIndex;
    [SerializeField] private bool continuesOnToNextLevel;
    [SerializeField] private string nextSceneName;

    [SerializeField] private AudioClip teleporting;

    SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite turnedOn;
    [SerializeField] private Sprite turnedOff;

    /*
    [SerializeField] private List<GameObject> shadow = new List<GameObject>();
    [SerializeField] private GameObject currentShadow;

    int indexForShadow = 0;
    */

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

    public void ShadowTeleport(GameObject shadowObject)
    {

        PlaySound();

        TeleportAnimationShadow(shadowObject);

        /*
        foreach (GameObject shadowObject in shadow)
        {
            Debug.Log("This is " + shadowObject);

            TeleportAnimationShadow(shadowObject);
        }

        shadow.Clear();
        */
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

        if (continuesOnToNextLevel)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else if (!continuesOnToNextLevel)
        {
            player.transform.position = emptyExit.position;

            while (stateInfo.IsName("TeleportBackAnim"))
            {
                yield return null;
                stateInfo = P_movment.playerAnimator.GetCurrentAnimatorStateInfo(0);
            }
        }

        Debug.Log("Teleporting Finished");
    }

    // This is for animations of Shadow Figures

    private void TeleportAnimationShadow(GameObject shadowObject)
    {
        Animator shadowAnimator = shadowObject.GetComponent<sadow_Mov>().shadowAnimator;
        bool isPlayingTeleAnimation = shadowObject.GetComponent<sadow_Mov>().isPlayingTeleAnimation;

        Debug.Log("Teleporting Shadow");
        shadowAnimator.SetBool("isTeleporting", true);
        StartCoroutine(WaitForTeleportAnimationShadow(shadowAnimator, isPlayingTeleAnimation, shadowObject));
    }

    private IEnumerator WaitForTeleportAnimationShadow(Animator shadowAnimator, bool isPlayingTeleAnimation, GameObject shadowObject)
    {
        yield return null;

        AnimatorStateInfo stateInfo = shadowAnimator.GetCurrentAnimatorStateInfo(0);

        /*
        while (stateInfo.IsName("TeleportForwardS"))
        {
            yield return null;
            stateInfo = shadowAnimator.GetCurrentAnimatorStateInfo(0);
        }
        yield return new WaitForSeconds(1.3f);
        */

        isPlayingTeleAnimation = false;
        shadowAnimator.SetBool("isTeleporting", false);

        shadowObject.transform.position = emptyExit.position;

        // FIX THAT THE FIRST SHADOW ENTERS THE PORTAL AND NOT IN THE SECOND LOOP. IT is probably because it checks the list twice, and it only registers after the second time
        /*
         * IT SEEMS TO BE FIXED, THOUGH IF IT OCCURS AGAIN. THE PROBLEM IS IT REGISTERS AFTER THE CODE RUNS SO THE SHADOWS DOESNT MAKE IT IN TIME
        indexForShadow = 0;
        foreach (GameObject gameObject in shadow)
        {
            shadow[indexForShadow].transform.position = emptyExit.position;
            indexForShadow++;
        }
        indexForShadow = 0;
        */

        while (stateInfo.IsName("TeleportBackwardS"))
        {
            yield return null;
            stateInfo = shadowAnimator.GetCurrentAnimatorStateInfo(0);
        }

        Debug.Log("Teleporting Shadow Finished");


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shadow"))
        {
            //shadow.Add(collision.gameObject);

            ShadowTeleport(collision.gameObject);

            Debug.Log("Shadow has entered Teleport Trigger");
        }
    }
}

public static class ExitTeleport
{
    public static Transform emptyExitGlobal;
}
