using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Vytvoření proměnných pro UI tlačítka a level selector
    private GameObject playB;
    private GameObject exitB;
    private GameObject backB;
    private GameObject levelSelector;
    public GameObject levelSelectorObj;
    private void Start()
    {
        //Při startu se podle jména nastaví proměnné na správná tlačítka
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
        //Při zmáčknutí tlačítka "Play" se pomocí funkce SetActive() zneviditelní a zviditelní tlačítka podle potřeby
        playB.SetActive(false);
        exitB.SetActive(false);
        backB.SetActive(true);
        //Vytvoření level selectoru v "Canvasu"
        levelSelector = Instantiate(levelSelectorObj, GameObject.Find("Canvas").transform);
    }

    public void BackButton()
    {
        playB.SetActive(true);
        exitB.SetActive(true);
        backB.SetActive(false);
        //Při návratu do menu se level selector zničí, aby nepřekrýval samotné menu
        Destroy(levelSelector);
    }

    public void LoadLevel(int levelIndex)
    {
        //Nastavení čísla levelu, který se má spawnout
        GameInstance.Instance.LevelManager.activeLevel = levelIndex;
        //Načtení herní scény "Game"
        SceneManager.LoadScene("Game");
    }
}
