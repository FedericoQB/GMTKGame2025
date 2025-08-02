using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampActivationScript : MonoBehaviour
{
    public int lampIndex;
    [SerializeField] private AudioClip successAudio;

    public void ActivateTorch()
    {
        Debug.Log("LampActivated");
        SoundFXManager.instance.PlaySoundFXClip(successAudio, transform, 1);
    }
}
