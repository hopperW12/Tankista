using UnityEngine;
using TMPro;

public class UINextLevel : MonoBehaviour
{
    //Odkaz na GameInstance
    private GameInstance instance = GameInstance.Instance;

    public GameObject button;

    void Start()
    {
        //Pokud není ve skriptu tlačítko nastaveno tak nic nenastavuj
        if (button == null)
            return;

        //Odkaz na text v tlačítku
        var text = button.GetComponentInChildren<TextMeshProUGUI>();

        int activeLevel = instance.LevelManager.activeLevel;
        if (activeLevel + 1 >= instance.LevelManager.levels.Count) {
            text.text = "Exit";
            //Add 
        } else {
            text.text = "Next level";
             button.GetComponent<Button>().onClick.AddListener(() =>
   {
        }
    }

}
