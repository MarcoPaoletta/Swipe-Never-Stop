using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockText : MonoBehaviour
{
    public Text clockText;
    public bool canSumMs = true;
    public Animator animator;

    public float ms;
    int lastTime;

    public void PlayClockTextAnimation()
    {
        animator.SetTrigger("clockText");
    }

    public void ResetTime()
    {
        clockText.text = (int)(ms * 1000) + " ms";
        ms = 0;
    }

    void Update()
    { 
        if(canSumMs)
        {
            ms += Time.deltaTime;
        }
    }
}
