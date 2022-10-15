using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public bool isGameStarted;
    public Color32[] healthBarColors;
    public Image healthBar;
    public Player player;
    public Text healthBarText;
    public float currentHealth;

    void Update()
    {
        if(isGameStarted)
        {
            healthBar.fillAmount = currentHealth;
            SetColor();
        }
    }

    void SetColor()
    {
        if(healthBar.fillAmount < 1 && healthBar.fillAmount > 0.75f)
        {
            SetHealthBarColor(0);
        }

        else if(healthBar.fillAmount < 0.75f && healthBar.fillAmount > 0.5f)
        {
            SetHealthBarColor(1);
        }

        else if(healthBar.fillAmount <= 0.5f && healthBar.fillAmount > 0.375f)
        {
            SetHealthBarColor(2);
        }

        else if(healthBar.fillAmount <= 0.375f && healthBar.fillAmount > 0.25f)
        {
            SetHealthBarColor(3);
        }

        else if(healthBar.fillAmount <= 0.25f && healthBar.fillAmount > 0.125f)
        {
            SetHealthBarColor(4);
        }

        else if(healthBar.fillAmount < 0.125f)
        {
            SetHealthBarColor(5);
        }
    }

    void SetHealthBarColor(int index)
    {
        healthBar.color = healthBarColors[index];
    }

    public void Start()
    {
        healthBar.color = healthBarColors[0];
        currentHealth = 1f;
        
        if(isGameStarted)
        {
            InvokeRepeating("DecreaseHealth", 0.01f, 0.01f);
        }
    }

    void DecreaseHealth()
    {
        if(!isDied())
        {
            currentHealth -= 0.0003f;
        }
        
        if(isDied())
        {
            player.GameOver();
        }
    }

    bool isDied()
    {
        if(currentHealth <= 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
