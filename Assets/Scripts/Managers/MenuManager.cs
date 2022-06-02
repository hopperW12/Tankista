using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Vytvoøení promìnných pro UI tlaèítka a level selector
    private GameObject playB;
    private GameObject exitB;
    private GameObject backB;
    private GameObject levelSelector;
    public GameObject levelSelectorObj;
    private void Start()
    {
        //Pøi startu se podle jména nastaví promìnné na správná tlaèítka
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
        //Pøi zmáèknutí tlaèítka "Play" se pomocí funkce SetActive() zneviditelní a zviditelní tlaèítka podle potøeby
        playB.SetActive(false);
        exitB.SetActive(false);
        backB.SetActive(true);
        //Vytvoøení level selectoru v "Canvasu"
        levelSelector = Instantiate(levelSelectorObj, GameObject.Find("Canvas").transform);
    }

    public void BackButton()
    {
        //30
        playB.SetActive(true);
        exitB.SetActive(true);
        backB.SetActive(false);
        //Pøi návratu do menu se level selector znièí, aby nepøekrýval samotné menu
        Destroy(levelSelector);
    }

    public void LoadLevel(int levelIndex)
    {
        //Nastavení èísla levelu, který se má spawnout
        GameInstance.Instance.LevelManager.activeLevel = levelIndex;
        //Naètení herní scény "Game"
        SceneManager.LoadScene("Game");
    }
}
