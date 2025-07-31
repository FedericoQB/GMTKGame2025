using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundExit : StateMachineBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField, Range(0, 1)] private float volume = 1;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundFXManager.instance.PlaySoundFXClip(audioClip, GameObject.FindWithTag("Player").transform, volume);
    }
}
