using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    public GameObject levelButtonObj;

    void Start()
    {
        //For přečte každý level a vytvoří pro něj tlačítko na start
        foreach (Level level in GameInstance.Instance.LevelManager.levels)
        {
            //Spawnutí předem nadefinovaného tlačítka
            GameObject button = Instantiate(levelButtonObj, gameObject.transform);
            //Nastavení textu tlačítka na číslo levelu
            button.GetComponentInChildren<TextMeshProUGUI>().text = level.name;

            //Vytvoření funkce pro tlačítko po kliknutí
            void TaskOnClick()
            {
                GameInstance.Instance.LevelManager.activeLevel = int.Parse(level.name) - 1;
                SceneManager.LoadScene("Game");
            }

            //Přidání funkce TaskOnClick() na tlačítko
            button.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        }
    }
}
