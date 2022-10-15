using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCanvas : MonoBehaviour
{
    public GameObject buttonsContainer;
    public GameObject fade;
    public Text scoreText;
    public Text bestText;

    int bestScore;

    void Start()
    {
        scoreText.text = "SCORE: " + Player.score.ToString();
        SetBestScore();
    }

    void SetBestScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", bestScore);
        PlayerPrefs.SetInt("BestScore", bestScore);

        if(Player.score > bestScore)
        {
            bestScore = Player.score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        
        bestText.text = "BEST: " + bestScore.ToString(); 
    }

    public void OnRestartButtonClicked()
    {
        buttonsContainer.gameObject.transform.Find("RestartButton").GetComponent<Button>().interactable = false;
        Player.score = 0;
        Player.isAlive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
