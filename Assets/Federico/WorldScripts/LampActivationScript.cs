using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampActivationScript : MonoBehaviour
{
    public int lampIndex;
    [SerializeField] private AudioClip successAudio;

    public void ActivateLamp()
    {
        Debug.Log("LampActivated");

        ExitDoorScript.lamps[lampIndex] = true;
        SoundFXManager.instance.PlaySoundFXClip(successAudio, transform, 1);
    }
}
