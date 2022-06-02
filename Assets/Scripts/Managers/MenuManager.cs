using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Vytvo�en� prom�nn�ch pro UI tla��tka a level selector
    private GameObject playB;
    private GameObject exitB;
    private GameObject backB;
    private GameObject levelSelector;
    public GameObject levelSelectorObj;
    private void Start()
    {
        //P�i startu se podle jm�na nastav� prom�nn� na spr�vn� tla��tka
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
        //P�i zm��knut� tla��tka "Play" se pomoc� funkce SetActive() zneviditeln� a zviditeln� tla��tka podle pot�eby
        playB.SetActive(false);
        exitB.SetActive(false);
        backB.SetActive(true);
        //Vytvo�en� level selectoru v "Canvasu"
        levelSelector = Instantiate(levelSelectorObj, GameObject.Find("Canvas").transform);
    }

    public void BackButton()
    {
        //30
        playB.SetActive(true);
        exitB.SetActive(true);
        backB.SetActive(false);
        //P�i n�vratu do menu se level selector zni��, aby nep�ekr�val samotn� menu
        Destroy(levelSelector);
    }

    public void LoadLevel(int levelIndex)
    {
        //Nastaven� ��sla levelu, kter� se m� spawnout
        GameInstance.Instance.LevelManager.activeLevel = levelIndex;
        //Na�ten� hern� sc�ny "Game"
        SceneManager.LoadScene("Game");
    }
}
