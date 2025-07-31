using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayQuickAnimationScript : MonoBehaviour
{
    Animator animator;

    public string nameOfBoolParameter;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimationForward()
    {
        animator.SetBool(nameOfBoolParameter, true);
    }

    public void PlayAnimationBackward()
    {
        animator.SetBool(nameOfBoolParameter, false);
    }
}
