using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UINextLevel : MonoBehaviour
{
    //Odkaz na GameInstance
    private GameInstance instance = GameInstance.Instance;

    public GameObject buttonObject;

    void Start()
    {
        //Pokud není ve skriptu tlačítko nastaveno tak nic nenastavuj
        if (buttonObject == null)
            return;
            
        var button = buttonObject.GetComponent<Button>();

        //Odkaz na text v tlačítku
        var text = buttonObject.GetComponentInChildren<TextMeshProUGUI>();

        int activeLevel = instance.LevelManager.activeLevel;

        //Pokud už není další level tak nastav se na exit
        if (activeLevel + 1 >= instance.LevelManager.levels.Count) {
            text.text = "Exit";
            button.onClick.AddListener(() => SceneManager.LoadScene("MainMenu")); //Přidání eventu
        } else {   
            text.text = "Next Level";
            button.onClick.AddListener(instance.LevelManager.NextLevel); //Přidání eventu
        }
    }

}