using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject trail;
    public HealthBar healthBar;
    public GameObject swipeText;
    public GameObject fade;

    void Start()
    {
        fade.SetActive(true);
        fade.GetComponent<Fade>().FadeIn();
    }

    void Update()
    {
        if(fade.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            swipeText.GetComponent<SwipeText>().Vanish();
            trail.SetActive(true);
            healthBar.isGameStarted = true;
            healthBar.GetComponent<HealthBar>().Start();
        }
    }
}
