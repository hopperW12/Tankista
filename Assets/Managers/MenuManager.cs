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
    public GameObject levelSelectorObj;

    private void Start()
    {
        playB = GameObject.Find("Play");
        exitB = GameObject.Find("Exit");
        backB = GameObject.Find("Back");

        backB.SetActive(false);
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
        levelSelector = Instantiate(levelSelectorObj, GameObject.Find("Canvas").transform);
    }

    public void BackButton()
    {
        playB.SetActive(true);
        exitB.SetActive(true);
        backB.SetActive(false);
        Destroy(levelSelector);
    }

    public void LoadLevel(int levelIndex)
    {
        GameInstance.Instance.LevelManager.activeLevel = levelIndex;
        SceneManager.LoadScene("Game");
    }
}
