using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaySceneUI : MonoBehaviour
{
    public Button restrartButton;
    public Button returnMainMenuButton;
    public Button playButton;
    public GameObject player;

    public void PlayButton()
    {
        player.SetActive(true);
        Time.timeScale = 1.0f;
        playButton.gameObject.SetActive(false);
    }
    public void RestartButton()
    {
        restrartButton.gameObject.SetActive(false);
        returnMainMenuButton.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void ReturnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
