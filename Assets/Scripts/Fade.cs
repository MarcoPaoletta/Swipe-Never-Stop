using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Image image;
    public Animator animator;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Settings" || SceneManager.GetActiveScene().name == "Credits")
        {
            FadeIn();
        }
    }

    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void FadeIn()
    {   
        animator.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
}
