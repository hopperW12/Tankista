using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private GameObject playB;
    private GameObject exitB;
    private GameObject backB;
    private GameObject levelSelector;

    private void Start()
    {
        playB = GameObject.Find("Play");
        exitB = GameObject.Find("Exit");
        backB = GameObject.Find("Back");
        levelSelector = GameObject.Find("LevelSelector");

        backB.SetActive(false);
        levelSelector.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void PlayButton()
    {
        playB.SetActive(false);
        exitB.SetActive(false);
        backB.SetActive(true);
        levelSelector.SetActive(true);
    }

    public void BackButton()
    {
        playB.SetActive(true);
        exitB.SetActive(true);
        backB.SetActive(false);
        levelSelector.SetActive(false);
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Game");
        GameInstance.Instance.LevelManager.activeLevel = levelIndex;
    }
}
