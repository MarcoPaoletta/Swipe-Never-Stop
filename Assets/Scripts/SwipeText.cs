using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeText : MonoBehaviour
{
    public Animator animator;

    public void Vanish()
    {
        animator.SetTrigger("Vanish");
    }
}
