using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    public Animator animator;

    public void PlayAnimation(string animationname)
    {
        animator.Play(animationname);
    }
}
