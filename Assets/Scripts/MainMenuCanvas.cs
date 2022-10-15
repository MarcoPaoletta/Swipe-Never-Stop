using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCanvas : MonoBehaviour
{
    public GameObject fade;
    public GameObject buttonsContainer;

    bool fadeCalled;
    string buttonClickedName;

    void Start()
    {
        fade.SetActive(true);
        fade.GetComponent<Fade>().FadeIn();
    }

    void FadeOut()
    {
        fade.SetActive(true);
        fade.GetComponent<Fade>().FadeOut();
        fadeCalled = true;
    }

    public void OnSceneChangerButtonClicked()
    {
        GameObject.Find("SceneChangerButton").GetComponent<Button>().interactable = false;
        FadeOut();
        buttonClickedName = "sceneChanger";
        AudioManager.PlayScoredAudio();
    }

    void Update()
    {
        if(fadeCalled && fade.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            if(buttonClickedName == "sceneChanger")
            {
                SceneManager.LoadScene("SampleScene");
            }
            if(buttonClickedName == "settings")
            {
                SceneManager.LoadScene("Settings");
            }
            if(buttonClickedName == "credits")
            {
                SceneManager.LoadScene("Credits");
            }
        }
    }

    public void OnSettingsButtonClicked()
    {
        buttonsContainer.transform.Find("SettingsButton").GetComponent<Button>().interactable = false;
        FadeOut();
        buttonClickedName = "settings";
    }

    public void OnCreditsButtonClicked()
    {
        buttonsContainer.transform.Find("CreditsButton").GetComponent<Button>().interactable = false;
        FadeOut();
        buttonClickedName = "credits";
    }

    public void OnYouTubeButtonClicked()
    {
        buttonsContainer.transform.Find("YouTubeButton").GetComponent<Button>().interactable = false;
        Application.OpenURL("https://www.youtube.com/channel/UCK7nhJBW05-tCmbmvbHThmw");
    }
}

