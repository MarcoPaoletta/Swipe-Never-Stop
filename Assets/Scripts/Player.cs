using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class Player : MonoBehaviour
{
    [Header ("Canvas")]
    public Canvas canvas;
    public Canvas scoreCanvas;
    public Canvas gameOVerCanvas;
    [Header ("GameObjects")]
    public GameObject arrow;
    public GameObject correctSwipedParticles;
    public GameObject everyTenCanvas;
    [Header ("Camera")]
    public Camera mainCamera;
    public CameraShake cameraShake;
    [Header("Scripts")]
    public Trail trail;
    public SwipeListener swipeListener;
    public ClockText clockText;
    public HealthBar healthBar;
    public ScoreText scoreText;

    bool gameStarted;

    public static bool isAlive = true;
    public static int score;

    void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }

    void OnSwipe(string swipe)
    {   if(healthBar.isGameStarted && isAlive)
        {
            if(swipe == "Up" && arrow.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                Scored("upShake");
            }
            
            else if(swipe == "UpLeft" && arrow.transform.rotation == Quaternion.Euler(0, 0, 45))
            {
                Scored("upLeftShake");
            }

            else if(swipe == "Left" && arrow.transform.rotation == Quaternion.Euler(0, 0, 90))
            {
                Scored("leftShake");
            }

            else if(swipe == "DownLeft" && arrow.transform.rotation == Quaternion.Euler(0, 0, 135))
            {
                Scored("downLeftShake");
            }

            else if(swipe == "Down" && arrow.transform.rotation == Quaternion.Euler(0, 0, 180))
            {
                Scored("downShake");
            }

            else if(swipe == "DownRight" && arrow.transform.rotation == Quaternion.Euler(0, 0, 225))
            {
                Scored("downRightShake");
            }

            else if(swipe == "Right" && arrow.transform.rotation == Quaternion.Euler(0, 0, 270))
            {
                Scored("rightShake");
            }

            else if(swipe == "UpRight" && arrow.transform.rotation == Quaternion.Euler(0, 0, 315))
            {
                Scored("upRightShake");
            }

            else
            {
                GameOver();
            }
        }
    }

    void Scored(string triggerName)
    {
        score += 1; 
        GenerateNewRotation();
        AddHealth();
        InstantiateCorrectSwipedParticles();
        mainCamera.GetComponent<MainCamera>().ChangeCameraBackgroundColor();
        trail.GetComponent<Trail>().ChangeTrailColor();
        cameraShake.MainCameraShake(triggerName);
        clockText.ResetTime();
        clockText.PlayClockTextAnimation();
        scoreText.PlayScoreTextAnimation();
        AudioManager.PlayScoredAudio();
        return;
    }

    void AddHealth()
    {
        int randomNumber = Random.Range(0, 4);
        
        if(randomNumber == 0 && healthBar.currentHealth <= 0.95f)
        {
            healthBar.currentHealth += 0.05f;
        }
    }

    public void InstantiateCorrectSwipedParticles()
    {
        Destroy(GameObject.FindGameObjectWithTag("CorrectSwipedParticles"));
        Instantiate(correctSwipedParticles, transform.position, Quaternion.identity);
    }

    void InstantiateEveryTenCanvas()
    {
        Destroy(GameObject.FindGameObjectWithTag("EveryTenCanvas"));
        Instantiate(everyTenCanvas, transform.position, Quaternion.identity);
    }

    void Start()
    {
        isAlive = true;
        gameStarted = true;
        GenerateNewRotation();
        mainCamera.GetComponent<MainCamera>().ChangeCameraBackgroundColor();
        score = 0;
    }

    public void GenerateNewRotation()
    {
        int randomNumber = Random.Range(1, 9);

        if(gameStarted)
        {
            if(randomNumber == 1 && arrow.transform.rotation != Quaternion.Euler(0, 0, 0))            
            {
                Rotate(0);
            }

            else if(randomNumber == 2 && arrow.transform.rotation != Quaternion.Euler(0, 0, 45))
            {
                Rotate(45);
            }

            else if(randomNumber == 3 && arrow.transform.rotation != Quaternion.Euler(0, 0, 90))
            {
                Rotate(90);
            }

            else if(randomNumber == 4 && arrow.transform.rotation != Quaternion.Euler(0, 0, 135))
            {
                Rotate(135);
            }

            else if(randomNumber == 5 && arrow.transform.rotation != Quaternion.Euler(0, 0, 180))
            {
                Rotate(180);
            }

            else if(randomNumber == 6 && arrow.transform.rotation != Quaternion.Euler(0, 0, 225))
            {
                Rotate(225);
            }

            else if(randomNumber == 7 && arrow.transform.rotation != Quaternion.Euler(0, 0, 270))
            {
                Rotate(270);
            }

            else if(randomNumber == 8 && arrow.transform.rotation != Quaternion.Euler(0, 0, 315))
            {
                Rotate(315);
            }

            else 
            {
                GenerateNewRotation();
            }
        }
    }

    void Rotate(int rotation)
    {
        arrow.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    public void GameOver()
    {
        isAlive = false;
        scoreCanvas.gameObject.SetActive(false);
        arrow.SetActive(false);
        trail.gameObject.SetActive(false);
        clockText.canSumMs = false;
        gameOVerCanvas.gameObject.SetActive(true);
        mainCamera.GetComponent<Camera>().backgroundColor = Color.red;
        AudioManager.PlayGameOverAudio();
    }
}