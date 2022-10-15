using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    public void OnHomeButtonClicked()
    {
        GetComponent<Button>().interactable = false;
        SceneManager.LoadScene("MainMenu");
    }
}
