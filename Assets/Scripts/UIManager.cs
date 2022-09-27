using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public Button playButton;
    public Button informaationButton;


    #region MainMenuButtons
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void XButton()
    {
        mainMenuPanel.SetActive(false);
        playButton.gameObject.SetActive(true);
        informaationButton.gameObject.SetActive(true);
    }
    public void InformationButton()
    {
        mainMenuPanel.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        informaationButton.gameObject.SetActive(false);
    }
    public void GitHubButton()
    {
        Application.OpenURL("https://github.com/BasarEkinci");
    }
    public void InstagramButton()
    {
        Application.OpenURL("https://www.instagram.com/basar.ekincii/");
    }
    public void LinkedinButton()
    {
        Application.OpenURL("https://l24.im/KU4");
    }
    public void TwitterButton()
    {
        Application.OpenURL("https://twitter.com/BasarEkincii");
    }
    #endregion
}
