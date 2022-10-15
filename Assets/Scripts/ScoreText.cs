using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;
    public Animator animator;

    void Update()
    {
        scoreText.text = "SCORE: " + Player.score.ToString() + " ";
    }

    public void PlayScoreTextAnimation()
    {
        animator.SetTrigger("ScoreText");
    }
}
